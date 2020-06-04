﻿using AssetStudio;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SkyEditor.IO.Binary;
using SkyEditor.IO.FileSystem;
using SkyEditor.RomEditor.Domain.Automation.CSharp;
using SkyEditor.RomEditor.Domain.Automation.Lua;
using SkyEditor.RomEditor.Domain.Rtdx.Models;
using SkyEditor.RomEditor.Domain.Rtdx.Structures;
using SkyEditor.RomEditor.Domain.Rtdx.Structures.Executable;
using SkyEditor.RomEditor.Infrastructure.Internal;
using System;
using System.IO;
using System.Text;

namespace SkyEditor.RomEditor.Domain.Rtdx
{
    public interface IRtdxRom
    {
        #region Exefs
        /// <summary>
        /// Gets the main executable, loading it if needed
        /// </summary>
        IMainExecutable GetMainExecutable();
        #endregion

        #region StreamingAssets/data
        /// <summary>
        /// Gets the personality test settings, loading it if needed
        /// </summary>
        NatureDiagnosisConfiguration GetNatureDiagnosis();
        #endregion

        #region StreamingAssets/native_data/pokemon
        PokemonDataInfo GetPokemonDataInfo();
        #endregion

        #region StreamingAssets/native_data/dungeon
        /// <summary>
        /// Gets static Pokemon data, loading it if needed
        /// </summary>
        IFixedPokemon GetFixedPokemon();
        #endregion

        #region StreamingAssets/native_data
        ICommonStrings GetCommonStrings();
        PokemonGraphicsDatabase GetPokemonGraphicsDatabase();
        PokemonFormDatabase GetPokemonFormDatabase();
        #endregion

        #region Models
        IStarterCollection GetStarters();
        #endregion

        /// <summary>
        /// Saves all loaded files to disk
        /// </summary>
        void Save(string directory, IFileSystem fileSystem);

        /// <summary>
        /// Saves all loaded files to disk
        /// </summary>
        void Save();
    }

    public class RtdxRom : IRtdxRom
    {
        public RtdxRom(string directory, IFileSystem fileSystem)
        {
            this.FileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException("Directory must not be null or empty", nameof(directory));
            }
            if (!fileSystem.DirectoryExists(directory))
            {
                throw new DirectoryNotFoundException("Directory must exist in the given file system");
            }
            this.RomDirectory = directory;
        }

        public string RomDirectory { get; }
        protected IFileSystem FileSystem { get; }

        protected IServiceProvider GetServiceProvider()
        {
            if (serviceProvider == null)
            {
                serviceProvider = ServiceProviderBuilder.CreateRtdxRomServiceProvider(this);
            }
            return serviceProvider;
        }
        private IServiceProvider? serviceProvider;

        #region ExeFs
        /// <summary>
        /// Gets the main executable, loading it if needed
        /// </summary>
        public IMainExecutable GetMainExecutable()
        {
            if (mainExecutable == null)
            {
                mainExecutable = MainExecutable.LoadFromNso(FileSystem.ReadAllBytes(GetNsoPath(this.RomDirectory)));
            }
            return mainExecutable;
        }
        private IMainExecutable? mainExecutable;

        protected static string GetNsoPath(string directory) => Path.Combine(directory, "exefs", "main");
        #endregion

        #region StreamingAssets/data
        /// <summary>
        /// Gets the personality test settings, loading it if needed
        /// </summary>
        public NatureDiagnosisConfiguration GetNatureDiagnosis()
        {
            if (natureDiagnosis == null)
            {
                natureDiagnosis = JsonConvert.DeserializeObject<NatureDiagnosisConfiguration>(FileSystem.ReadAllText(GetNatureDiagnosisPath(this.RomDirectory)));
            }
            return natureDiagnosis;
        }
        private NatureDiagnosisConfiguration? natureDiagnosis;
        protected static string GetNatureDiagnosisPath(string directory) => Path.Combine(directory, "romfs/Data/StreamingAssets/data/nature_diagnosis/diagnosis.json");
        #endregion

        #region StreamingAssets/data/ab
        /// <summary>
        /// Loads asset bundles
        /// Note: If the ROM is not a physical file system, exceptions may occur.
        /// </summary>
        public AssetsManager GetAssetBundles()
        {
            if (_assetBundles == null)
            {
                _assetBundles = new AssetsManager();
                _assetBundles.LoadFolder(this.FileSystem, GetAssetBundlesPath(this.RomDirectory));
            }
            return _assetBundles;
        }
        private AssetsManager? _assetBundles;
        protected static string GetAssetBundlesPath(string directory) => Path.Combine(directory, "romfs/Data/StreamingAssets/ab");

        #endregion

        #region StreamingAssets/native_data/pokemon
        public PokemonDataInfo GetPokemonDataInfo()
        {
            if (pokemonDataInfo == null)
            {
                pokemonDataInfo = new PokemonDataInfo(new BinaryFile(FileSystem.ReadAllBytes(GetPokemonDataInfoPath(this.RomDirectory))));
            }
            return pokemonDataInfo;
        }
        private PokemonDataInfo? pokemonDataInfo;
        protected static string GetPokemonDataInfoPath(string directory) => Path.Combine(directory, "romfs/Data/StreamingAssets/native_data/pokemon/pokemon_data_info.bin");

        #endregion

        #region StreamingAssets/native_data/dungeon
        /// <summary>
        /// Gets static Pokemon data, loading it if needed
        /// </summary>
        public IFixedPokemon GetFixedPokemon()
        {
            if (fixedPokemon == null)
            {
                fixedPokemon = new FixedPokemon(FileSystem.ReadAllBytes(GetFixedPokemonPath(this.RomDirectory)));
            }
            return fixedPokemon;
        }
        private IFixedPokemon? fixedPokemon;

        protected static string GetFixedPokemonPath(string directory) => Path.Combine(directory, "romfs/Data/StreamingAssets/native_data/dungeon/fixed_pokemon.bin");
        #endregion

        #region StreamingAssets/native_data
        public PokemonFormDatabase GetPokemonFormDatabase()
        {
            if (pokemonFormDatabase == null)
            {
                pokemonFormDatabase = new PokemonFormDatabase(File.ReadAllBytes(GetPokemonFormDatabasePath(this.RomDirectory)));
            }
            return pokemonFormDatabase;
        }
        private PokemonFormDatabase? pokemonFormDatabase;
        protected static string GetPokemonFormDatabasePath(string directory) => Path.Combine(directory, "romfs/Data/StreamingAssets/native_data/pokemon_form_database.bin");

        public PokemonGraphicsDatabase GetPokemonGraphicsDatabase()
        {
            if (pokemonGraphicsDatabase == null)
            {
                pokemonGraphicsDatabase = new PokemonGraphicsDatabase(File.ReadAllBytes(GetPokemonGraphicsDatabasePath(this.RomDirectory)));
            }
            return pokemonGraphicsDatabase;
        }
        private PokemonGraphicsDatabase? pokemonGraphicsDatabase;
        protected static string GetPokemonGraphicsDatabasePath(string directory) => Path.Combine(directory, "romfs/Data/StreamingAssets/native_data/pokemon_graphics_database.bin");

        public Farc GetUSMessageBin()
        {
            if (messageBin == null)
            {
                var messageBinPath = MessageBinUSPath;
                messageBin = new Farc(File.ReadAllBytes(messageBinPath));
            }
            return messageBin;
        }
        private Farc? messageBin;
        protected string MessageBinUSPath => Path.Combine(RomDirectory, "romfs/Data/StreamingAssets/native_data/message_us.bin");

        public ICommonStrings GetCommonStrings()
        {
            if (commonStrings == null)
            {
                var commonData = GetUSMessageBin().GetFile("common.bin");
                if (commonData == null)
                {
                    throw new Exception("Unable to load common.bin from " + MessageBinUSPath);
                }

                var common = new MessageBinEntry(commonData);
                commonStrings = new CommonStrings(common);
            }
            return commonStrings;
        }
        private ICommonStrings? commonStrings;
        #endregion

        #region Models
        public IStarterCollection GetStarters()
        {
            if (starterCollection == null)
            {
                var sp = GetServiceProvider();
                starterCollection = new StarterCollection(this,
                    sp.GetRequiredService<ILuaGenerator>(),
                    sp.GetRequiredService<ICSharpGenerator>());
            }
            return starterCollection;
        }
        private StarterCollection? starterCollection;
        #endregion

        /// <summary>
        /// Saves all loaded files to disk
        /// </summary>
        public void Save(string directory, IFileSystem fileSystem)
        {
            // Save wrappers around files
            if (starterCollection != null)
            {
                starterCollection.Flush();
            }

            // Save the files themselves
            if (mainExecutable != null)
            {
                var path = GetNsoPath(directory);
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                fileSystem.WriteAllBytes(path, mainExecutable.ToNso());
            }
            if (natureDiagnosis != null)
            {
                var path = GetNatureDiagnosisPath(directory);
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                fileSystem.WriteAllText(path, JsonConvert.SerializeObject(natureDiagnosis));
            }
            if (fixedPokemon != null)
            {
                var path = GetFixedPokemonPath(directory);
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                fileSystem.WriteAllBytes(path, fixedPokemon.Build().Data.ReadArray());
            }
            if (pokemonDataInfo != null)
            {
                var path = GetPokemonDataInfoPath(directory);
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                fileSystem.WriteAllBytes(path, pokemonDataInfo.ToByteArray());
            }

            // To-do: save commonStrings when implemented
            // To-do: save messageBin when implemented
            // To-do: save pokemonFormDatabase when implemented

            if (pokemonGraphicsDatabase != null)
            {
                var path = GetPokemonGraphicsDatabasePath(directory);
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                fileSystem.WriteAllBytes(path, pokemonGraphicsDatabase.ToByteArray());
            }
        }

        /// <summary>
        /// Saves all loaded files to disk
        /// </summary>
        public void Save()
        {
            this.Save(this.RomDirectory, this.FileSystem);
        }

        public string GenerateLuaChangeScript(int indentLevel = 0)
        {
            var script = new StringBuilder();
            script.Append(LuaSnippets.RequireSkyEditor);
            script.AppendLine();
            if (starterCollection != null)
            {
                script.Append(starterCollection.GenerateLuaChangeScript(indentLevel));
            }
            return script.ToString();
        }

        public string GenerateCSharpChangeScript(int indentLevel = 0)
        {
            var script = new StringBuilder();
            script.Append(CSharpSnippets.RequireSkyEditor);
            script.AppendLine();
            if (starterCollection != null)
            {
                script.Append(starterCollection.GenerateCSharpChangeScript(indentLevel));
            }
            return script.ToString();
        }
    }
}