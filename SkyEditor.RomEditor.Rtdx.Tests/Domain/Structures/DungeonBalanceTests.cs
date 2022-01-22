﻿using FluentAssertions;
using SkyEditor.RomEditor.Domain.Rtdx.Constants;
using SkyEditor.RomEditor.Domain.Rtdx.Structures;
using System.Threading.Tasks;
using Xunit;

namespace SkyEditor.RomEditor.Tests.Domain.Structures
{
    public class DungeonBalanceTests
    {
        [Fact]
        public async Task CanBuildDungeonBalanceTests()
        {
            // Arrange
            var db = new DungeonBalance();

            var d001 = db.Entries[(int)DungeonIndex.D001] = new DungeonBalance.Entry(2);
            d001.FloorInfos[0].Short02 = 0x02;
            d001.FloorInfos[0].Event = "@BOSS#0";
            d001.FloorInfos[0].TurnLimit = 0x24;
            d001.FloorInfos[0].MinMoneyStackSize = 0x26;
            d001.FloorInfos[0].MaxMoneyStackSize = 0x28;
            d001.FloorInfos[0].DungeonMapDataInfoIndex = 0x2A;
            d001.FloorInfos[0].NameID = 0x2C;
            d001.FloorInfos[0].Byte2D = 0x2D;
            d001.FloorInfos[0].Byte2E = 0x2E;
            d001.FloorInfos[0].Byte2F = 0x2F;
            d001.FloorInfos[0].Short30 = 0x30;
            d001.FloorInfos[0].Short32 = 0x32;
            d001.FloorInfos[0].Byte34 = 0x34;
            d001.FloorInfos[0].Byte35 = 0x35;
            d001.FloorInfos[0].ItemSetIndex = 0x36;
            d001.FloorInfos[0].BuriedItemSetIndex = 0x44;
            d001.FloorInfos[0].MaxBuriedItems = 0x45;
            d001.FloorInfos[0].Byte46 = 0x46;
            d001.FloorInfos[0].Byte47 = 0x47;
            d001.FloorInfos[0].KecleonShopChance = 0x48;
            d001.FloorInfos[0].Byte49 = 0x49;
            d001.FloorInfos[0].Byte4A = 0x4A;
            d001.FloorInfos[0].MinTrapDensity = 0x4B;
            d001.FloorInfos[0].MaxTrapDensity = 0x4C;
            d001.FloorInfos[0].MinEnemyDensity = 0x4D;
            d001.FloorInfos[0].MaxEnemyDensity = 0x4E;
            d001.FloorInfos[0].Byte4F = 0x4F;
            d001.FloorInfos[0].Byte50 = 0x50;
            d001.FloorInfos[0].Byte51 = 0x51;
            d001.FloorInfos[0].MysteryHouseChance = 0x52;
            d001.FloorInfos[0].MysteryHouseSize = 0x53;
            d001.FloorInfos[0].InvitationIndex = 0x54;
            d001.FloorInfos[0].MonsterHouseChance = 0x55;
            d001.FloorInfos[0].Byte56 = 0x56;
            d001.FloorInfos[0].Byte57 = 0x57;
            d001.FloorInfos[0].Byte58 = 0x58;
            d001.FloorInfos[0].Weather = (DungeonStatusIndex)0x59;

            d001.FloorInfos[1].Short02 = 0x202;
            d001.FloorInfos[1].Event = "@END";
            d001.FloorInfos[1].TurnLimit = 0x224;
            d001.FloorInfos[1].MinMoneyStackSize = 0x226;
            d001.FloorInfos[1].MaxMoneyStackSize = 0x228;
            d001.FloorInfos[1].DungeonMapDataInfoIndex = 0x22A;
            d001.FloorInfos[1].NameID = 0xFF;
            d001.FloorInfos[1].Byte2D = 0xFE;
            d001.FloorInfos[1].Byte2E = 0xFD;
            d001.FloorInfos[1].Byte2F = 0xFC;
            d001.FloorInfos[1].Short30 = 0x230;
            d001.FloorInfos[1].Short32 = 0x232;
            d001.FloorInfos[1].Byte34 = 0xFB;
            d001.FloorInfos[1].Byte35 = 0xFA;
            d001.FloorInfos[1].ItemSetIndex = 0xF9;
            d001.FloorInfos[1].BuriedItemSetIndex = 0xF8;
            d001.FloorInfos[1].MaxBuriedItems = 0xF7;
            d001.FloorInfos[1].Byte46 = 0xF6;
            d001.FloorInfos[1].Byte47 = 0xF5;
            d001.FloorInfos[1].KecleonShopChance = 0xF4;
            d001.FloorInfos[1].Byte49 = 0xF3;
            d001.FloorInfos[1].Byte4A = 0xF2;
            d001.FloorInfos[1].MinTrapDensity = 0xF1;
            d001.FloorInfos[1].MaxTrapDensity = 0xF0;
            d001.FloorInfos[1].MinEnemyDensity = 0xEF;
            d001.FloorInfos[1].MaxEnemyDensity = 0xEE;
            d001.FloorInfos[1].Byte4F = 0xED;
            d001.FloorInfos[1].Byte50 = 0xEC;
            d001.FloorInfos[1].Byte51 = 0xEB;
            d001.FloorInfos[1].MysteryHouseChance = 0xEA;
            d001.FloorInfos[1].MysteryHouseSize = 0xE9;
            d001.FloorInfos[1].InvitationIndex = 0xE8;
            d001.FloorInfos[1].MonsterHouseChance = 0xE7;
            d001.FloorInfos[1].Byte56 = 0xE6;
            d001.FloorInfos[1].Byte57 = 0xE5;
            d001.FloorInfos[1].Byte58 = 0xE4;
            d001.FloorInfos[1].Weather = (DungeonStatusIndex)0xE3;

            d001.WildPokemon = new DungeonBalance.WildPokemonInfo();
            var d001Bulbasaur = d001.WildPokemon.Stats[(int)CreatureIndex.FUSHIGIDANE];
            d001Bulbasaur.Index = (int)CreatureIndex.FUSHIGIDANE;
            d001Bulbasaur.XPYield = 10;
            d001Bulbasaur.HitPoints = 33;
            d001Bulbasaur.Attack = 15;
            d001Bulbasaur.Defense = 10;
            d001Bulbasaur.SpecialAttack = 17;
            d001Bulbasaur.SpecialDefense = 15;
            d001Bulbasaur.Speed = 12;
            d001Bulbasaur.StrongFoe = 0;
            d001Bulbasaur.Level = 5;

            var d001Charmander = d001.WildPokemon.Stats[(int)CreatureIndex.HITOKAGE];
            d001Charmander.Index = (int)CreatureIndex.HITOKAGE;
            d001Charmander.XPYield = 11;
            d001Charmander.HitPoints = 28;
            d001Charmander.Attack = 13;
            d001Charmander.Defense = 12;
            d001Charmander.SpecialAttack = 18;
            d001Charmander.SpecialDefense = 14;
            d001Charmander.Speed = 12;
            d001Charmander.StrongFoe = 0;
            d001Charmander.Level = 5;

            var d001Floor1 = d001.WildPokemon.Floors[0];
            d001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].PokemonIndex = (int)CreatureIndex.FUSHIGIDANE;
            d001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].SpawnRate = 100;
            d001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].RecruitmentLevel = 5;
            d001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].Byte0B = 0;

            d001Floor1.Entries[(int)CreatureIndex.HITOKAGE].PokemonIndex = (int)CreatureIndex.HITOKAGE;
            d001Floor1.Entries[(int)CreatureIndex.HITOKAGE].SpawnRate = 100;
            d001Floor1.Entries[(int)CreatureIndex.HITOKAGE].RecruitmentLevel = 5;
            d001Floor1.Entries[(int)CreatureIndex.HITOKAGE].Byte0B = 0;

            var trapWeights = d001.TrapWeights = new DungeonBalance.TrapWeights();
            trapWeights.Records[0].Entries[0].Index = 0;
            trapWeights.Records[0].Entries[0].Weight = 0x02;
            trapWeights.Records[0].Entries[0].Int04 = 0x04;
            trapWeights.Records[1].Entries[1].Index = 1;
            trapWeights.Records[1].Entries[1].Weight = 0x102;
            trapWeights.Records[1].Entries[1].Int04 = 0x104;

            var d001Data4 = d001.Data4 = new DungeonBalance.DungeonBalanceDataEntry4();
            d001Data4.Records[0].Entries[0].Short00 = 0x00;
            d001Data4.Records[0].Entries[0].Short02 = 0x02;
            d001Data4.Records[0].Entries[0].Int04 = 0x04;
            d001Data4.Records[1].Entries[1].Short00 = 0x100;
            d001Data4.Records[1].Entries[1].Short02 = 0x102;
            d001Data4.Records[1].Entries[1].Int04 = 0x104;

            var d002 = db.Entries[(int)DungeonIndex.D002] = new DungeonBalance.Entry(1);
            d002.FloorInfos[0].Short02 = 0x302;
            d002.FloorInfos[0].Event = "@END";
            d002.FloorInfos[0].TurnLimit = 0x324;
            d002.FloorInfos[0].MinMoneyStackSize = 0x326;
            d002.FloorInfos[0].MaxMoneyStackSize = 0x328;
            d002.FloorInfos[0].DungeonMapDataInfoIndex = 0x32A;
            d002.FloorInfos[0].NameID = 0xE2;
            d002.FloorInfos[0].Byte2D = 0xE1;
            d002.FloorInfos[0].Byte2E = 0xE0;
            d002.FloorInfos[0].Byte2F = 0xDF;
            d002.FloorInfos[0].Short30 = 0x330;
            d002.FloorInfos[0].Short32 = 0x332;
            d002.FloorInfos[0].Byte34 = 0xDE;
            d002.FloorInfos[0].Byte35 = 0xDD;
            d002.FloorInfos[0].ItemSetIndex = 0xDC;
            d002.FloorInfos[0].BuriedItemSetIndex = 0xDB;
            d002.FloorInfos[0].MaxBuriedItems = 0xDA;
            d002.FloorInfos[0].Byte46 = 0xD9;
            d002.FloorInfos[0].Byte47 = 0xD8;
            d002.FloorInfos[0].KecleonShopChance = 0xD7;
            d002.FloorInfos[0].Byte49 = 0xD6;
            d002.FloorInfos[0].Byte4A = 0xD5;
            d002.FloorInfos[0].MinTrapDensity = 0xD4;
            d002.FloorInfos[0].MaxTrapDensity = 0xD3;
            d002.FloorInfos[0].MinEnemyDensity = 0xD2;
            d002.FloorInfos[0].MaxEnemyDensity = 0xD1;
            d002.FloorInfos[0].Byte4F = 0xD0;
            d002.FloorInfos[0].Byte50 = 0xCF;
            d002.FloorInfos[0].Byte51 = 0xCE;
            d002.FloorInfos[0].MysteryHouseChance = 0xCD;
            d002.FloorInfos[0].MysteryHouseSize = 0xCC;
            d002.FloorInfos[0].InvitationIndex = 0xCB;
            d002.FloorInfos[0].MonsterHouseChance = 0xCA;
            d002.FloorInfos[0].Byte56 = 0xC9;
            d002.FloorInfos[0].Byte57 = 0xC8;
            d002.FloorInfos[0].Byte58 = 0xC7;
            d002.FloorInfos[0].Weather = (DungeonStatusIndex)0xC6;

            // Act
            var (bin, ent) = await db.Build();

            // Assert
            var rebuiltDb = new DungeonBalance(bin, ent);

            var rebuiltD001 = rebuiltDb.Entries[(int)DungeonIndex.D001];
            rebuiltD001.FloorInfos.Should().HaveCount(2);
            rebuiltD001.FloorInfos[0].Short02.Should().Be(0x02);
            rebuiltD001.FloorInfos[0].Event.Should().Be("@BOSS#0");
            rebuiltD001.FloorInfos[0].TurnLimit.Should().Be(0x24);
            rebuiltD001.FloorInfos[0].MinMoneyStackSize.Should().Be(0x26);
            rebuiltD001.FloorInfos[0].MaxMoneyStackSize.Should().Be(0x28);
            rebuiltD001.FloorInfos[0].DungeonMapDataInfoIndex.Should().Be(0x2A);
            rebuiltD001.FloorInfos[0].NameID.Should().Be(0x2C);
            rebuiltD001.FloorInfos[0].Byte2D.Should().Be(0x2D);
            rebuiltD001.FloorInfos[0].Byte2E.Should().Be(0x2E);
            rebuiltD001.FloorInfos[0].Byte2F.Should().Be(0x2F);
            rebuiltD001.FloorInfos[0].Short30.Should().Be(0x30);
            rebuiltD001.FloorInfos[0].Short32.Should().Be(0x32);
            rebuiltD001.FloorInfos[0].Byte34.Should().Be(0x34);
            rebuiltD001.FloorInfos[0].Byte35.Should().Be(0x35);
            rebuiltD001.FloorInfos[0].ItemSetIndex.Should().Be(0x36);
            rebuiltD001.FloorInfos[0].BuriedItemSetIndex.Should().Be(0x44);
            rebuiltD001.FloorInfos[0].MaxBuriedItems.Should().Be(0x45);
            rebuiltD001.FloorInfos[0].Byte46.Should().Be(0x46);
            rebuiltD001.FloorInfos[0].Byte47.Should().Be(0x47);
            rebuiltD001.FloorInfos[0].KecleonShopChance.Should().Be(0x48);
            rebuiltD001.FloorInfos[0].Byte49.Should().Be(0x49);
            rebuiltD001.FloorInfos[0].Byte4A.Should().Be(0x4A);
            rebuiltD001.FloorInfos[0].MinTrapDensity.Should().Be(0x4B);
            rebuiltD001.FloorInfos[0].MaxTrapDensity.Should().Be(0x4C);
            rebuiltD001.FloorInfos[0].MinEnemyDensity.Should().Be(0x4D);
            rebuiltD001.FloorInfos[0].MaxEnemyDensity.Should().Be(0x4E);
            rebuiltD001.FloorInfos[0].Byte4F.Should().Be(0x4F);
            rebuiltD001.FloorInfos[0].Byte50.Should().Be(0x50);
            rebuiltD001.FloorInfos[0].Byte51.Should().Be(0x51);
            rebuiltD001.FloorInfos[0].MysteryHouseChance.Should().Be(0x52);
            rebuiltD001.FloorInfos[0].MysteryHouseSize.Should().Be(0x53);
            rebuiltD001.FloorInfos[0].InvitationIndex.Should().Be(0x54);
            rebuiltD001.FloorInfos[0].MonsterHouseChance.Should().Be(0x55);
            rebuiltD001.FloorInfos[0].Byte56.Should().Be(0x56);
            rebuiltD001.FloorInfos[0].Byte57.Should().Be(0x57);
            rebuiltD001.FloorInfos[0].Byte58.Should().Be(0x58);
            rebuiltD001.FloorInfos[0].Weather.Should().Be((DungeonStatusIndex)0x59);
            rebuiltD001.FloorInfos[0].InvitationIndex.Should().Be(0x54);

            rebuiltD001.FloorInfos[1].Short02.Should().Be(0x202);
            rebuiltD001.FloorInfos[1].Event.Should().Be("@END");
            rebuiltD001.FloorInfos[1].TurnLimit.Should().Be(0x224);
            rebuiltD001.FloorInfos[1].MinMoneyStackSize.Should().Be(0x226);
            rebuiltD001.FloorInfos[1].MaxMoneyStackSize.Should().Be(0x228);
            rebuiltD001.FloorInfos[1].DungeonMapDataInfoIndex.Should().Be(0x22A);
            rebuiltD001.FloorInfos[1].NameID.Should().Be(0xFF);
            rebuiltD001.FloorInfos[1].Byte2D.Should().Be(0xFE);
            rebuiltD001.FloorInfos[1].Byte2E.Should().Be(0xFD);
            rebuiltD001.FloorInfos[1].Byte2F.Should().Be(0xFC);
            rebuiltD001.FloorInfos[1].Short30.Should().Be(0x230);
            rebuiltD001.FloorInfos[1].Short32.Should().Be(0x232);
            rebuiltD001.FloorInfos[1].Byte34.Should().Be(0xFB);
            rebuiltD001.FloorInfos[1].Byte35.Should().Be(0xFA);
            rebuiltD001.FloorInfos[1].ItemSetIndex.Should().Be(0xF9);
            rebuiltD001.FloorInfos[1].BuriedItemSetIndex.Should().Be(0xF8);
            rebuiltD001.FloorInfos[1].MaxBuriedItems.Should().Be(0xF7);
            rebuiltD001.FloorInfos[1].Byte46.Should().Be(0xF6);
            rebuiltD001.FloorInfos[1].Byte47.Should().Be(0xF5);
            rebuiltD001.FloorInfos[1].KecleonShopChance.Should().Be(0xF4);
            rebuiltD001.FloorInfos[1].Byte49.Should().Be(0xF3);
            rebuiltD001.FloorInfos[1].Byte4A.Should().Be(0xF2);
            rebuiltD001.FloorInfos[1].MinTrapDensity.Should().Be(0xF1);
            rebuiltD001.FloorInfos[1].MaxTrapDensity.Should().Be(0xF0);
            rebuiltD001.FloorInfos[1].MinEnemyDensity.Should().Be(0xEF);
            rebuiltD001.FloorInfos[1].MaxEnemyDensity.Should().Be(0xEE);
            rebuiltD001.FloorInfos[1].Byte4F.Should().Be(0xED);
            rebuiltD001.FloorInfos[1].Byte50.Should().Be(0xEC);
            rebuiltD001.FloorInfos[1].Byte51.Should().Be(0xEB);
            rebuiltD001.FloorInfos[1].MysteryHouseChance.Should().Be(0xEA);
            rebuiltD001.FloorInfos[1].MysteryHouseSize.Should().Be(0xE9);
            rebuiltD001.FloorInfos[1].InvitationIndex.Should().Be(0xE8);
            rebuiltD001.FloorInfos[1].MonsterHouseChance.Should().Be(0xE7);
            rebuiltD001.FloorInfos[1].Byte56.Should().Be(0xE6);
            rebuiltD001.FloorInfos[1].Byte57.Should().Be(0xE5);
            rebuiltD001.FloorInfos[1].Byte58.Should().Be(0xE4);
            rebuiltD001.FloorInfos[1].Weather.Should().Be((DungeonStatusIndex)0xE3);

            rebuiltD001.WildPokemon.Should().NotBeNull();
            if (rebuiltD001.WildPokemon != null)
            {
                var rebuiltD001Bulbasaur = rebuiltD001.WildPokemon.Stats[(int)CreatureIndex.FUSHIGIDANE];
                rebuiltD001Bulbasaur.Index.Should().Be((int)CreatureIndex.FUSHIGIDANE);
                rebuiltD001Bulbasaur.XPYield.Should().Be(10);
                rebuiltD001Bulbasaur.HitPoints.Should().Be(33);
                rebuiltD001Bulbasaur.Attack.Should().Be(15);
                rebuiltD001Bulbasaur.Defense.Should().Be(10);
                rebuiltD001Bulbasaur.SpecialAttack.Should().Be(17);
                rebuiltD001Bulbasaur.SpecialDefense.Should().Be(15);
                rebuiltD001Bulbasaur.Speed.Should().Be(12);
                rebuiltD001Bulbasaur.StrongFoe.Should().Be(0);
                rebuiltD001Bulbasaur.Level.Should().Be(5);

                var rebuiltD001Charmander = rebuiltD001.WildPokemon.Stats[(int)CreatureIndex.HITOKAGE];
                rebuiltD001Charmander.Index.Should().Be((int)CreatureIndex.HITOKAGE);
                rebuiltD001Charmander.XPYield.Should().Be(11);
                rebuiltD001Charmander.HitPoints.Should().Be(28);
                rebuiltD001Charmander.Attack.Should().Be(13);
                rebuiltD001Charmander.Defense.Should().Be(12);
                rebuiltD001Charmander.SpecialAttack.Should().Be(18);
                rebuiltD001Charmander.SpecialDefense.Should().Be(14);
                rebuiltD001Charmander.Speed.Should().Be(12);
                rebuiltD001Charmander.StrongFoe.Should().Be(0);
                rebuiltD001Charmander.Level.Should().Be(5);

                var rebuiltD001Floor1 = rebuiltD001.WildPokemon.Floors[0];
                rebuiltD001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].PokemonIndex.Should().Be((int)CreatureIndex.FUSHIGIDANE);
                rebuiltD001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].SpawnRate.Should().Be(100);
                rebuiltD001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].RecruitmentLevel.Should().Be(5);
                rebuiltD001Floor1.Entries[(int)CreatureIndex.FUSHIGIDANE].Byte0B.Should().Be(0);

                rebuiltD001Floor1.Entries[(int)CreatureIndex.HITOKAGE].PokemonIndex.Should().Be((int)CreatureIndex.HITOKAGE);
                rebuiltD001Floor1.Entries[(int)CreatureIndex.HITOKAGE].SpawnRate.Should().Be(100);
                rebuiltD001Floor1.Entries[(int)CreatureIndex.HITOKAGE].RecruitmentLevel.Should().Be(5);
                rebuiltD001Floor1.Entries[(int)CreatureIndex.HITOKAGE].Byte0B.Should().Be(0);
            }

            var rebuiltD001TrapWeights = rebuiltD001.TrapWeights;
            rebuiltD001TrapWeights.Should().NotBeNull();
            if (rebuiltD001TrapWeights != null)
            {
                rebuiltD001TrapWeights.Records[0].Entries[0].Index.Should().Be(0);
                rebuiltD001TrapWeights.Records[0].Entries[0].Weight.Should().Be(0x02);
                rebuiltD001TrapWeights.Records[0].Entries[0].Int04.Should().Be(0x04);
                rebuiltD001TrapWeights.Records[1].Entries[1].Index.Should().Be(1);
                rebuiltD001TrapWeights.Records[1].Entries[1].Weight.Should().Be(0x102);
                rebuiltD001TrapWeights.Records[1].Entries[1].Int04.Should().Be(0x104);
            }

            var rebuiltD001Data4 = rebuiltD001.Data4;
            rebuiltD001Data4.Should().NotBeNull();
            if (rebuiltD001Data4 != null)
            {
                rebuiltD001Data4.Records[0].Entries[0].Short00.Should().Be(0x00);
                rebuiltD001Data4.Records[0].Entries[0].Short02.Should().Be(0x02);
                rebuiltD001Data4.Records[0].Entries[0].Int04.Should().Be(0x04);
                rebuiltD001Data4.Records[1].Entries[1].Short00.Should().Be(0x100);
                rebuiltD001Data4.Records[1].Entries[1].Short02.Should().Be(0x102);
                rebuiltD001Data4.Records[1].Entries[1].Int04.Should().Be(0x104);
            }

            var rebuiltD002 = rebuiltDb.Entries[(int)DungeonIndex.D002];
            rebuiltD002.FloorInfos.Should().HaveCount(1);
            rebuiltD002.FloorInfos[0].Short02.Should().Be(0x302);
            rebuiltD002.FloorInfos[0].Event.Should().Be("@END");
            rebuiltD002.FloorInfos[0].TurnLimit.Should().Be(0x324);
            rebuiltD002.FloorInfos[0].MinMoneyStackSize.Should().Be(0x326);
            rebuiltD002.FloorInfos[0].MaxMoneyStackSize.Should().Be(0x328);
            rebuiltD002.FloorInfos[0].DungeonMapDataInfoIndex.Should().Be(0x32A);
            rebuiltD002.FloorInfos[0].NameID.Should().Be(0xE2);
            rebuiltD002.FloorInfos[0].Byte2D.Should().Be(0xE1);
            rebuiltD002.FloorInfos[0].Byte2E.Should().Be(0xE0);
            rebuiltD002.FloorInfos[0].Byte2F.Should().Be(0xDF);
            rebuiltD002.FloorInfos[0].Short30.Should().Be(0x330);
            rebuiltD002.FloorInfos[0].Short32.Should().Be(0x332);
            rebuiltD002.FloorInfos[0].Byte34.Should().Be(0xDE);
            rebuiltD002.FloorInfos[0].Byte35.Should().Be(0xDD);
            rebuiltD002.FloorInfos[0].ItemSetIndex.Should().Be(0xDC);
            rebuiltD002.FloorInfos[0].BuriedItemSetIndex.Should().Be(0xDB);
            rebuiltD002.FloorInfos[0].MaxBuriedItems.Should().Be(0xDA);
            rebuiltD002.FloorInfos[0].Byte46.Should().Be(0xD9);
            rebuiltD002.FloorInfos[0].Byte47.Should().Be(0xD8);
            rebuiltD002.FloorInfos[0].KecleonShopChance.Should().Be(0xD7);
            rebuiltD002.FloorInfos[0].Byte49.Should().Be(0xD6);
            rebuiltD002.FloorInfos[0].Byte4A.Should().Be(0xD5);
            rebuiltD002.FloorInfos[0].MinTrapDensity.Should().Be(0xD4);
            rebuiltD002.FloorInfos[0].MaxTrapDensity.Should().Be(0xD3);
            rebuiltD002.FloorInfos[0].MinEnemyDensity.Should().Be(0xD2);
            rebuiltD002.FloorInfos[0].MaxEnemyDensity.Should().Be(0xD1);
            rebuiltD002.FloorInfos[0].Byte4F.Should().Be(0xD0);
            rebuiltD002.FloorInfos[0].Byte50.Should().Be(0xCF);
            rebuiltD002.FloorInfos[0].Byte51.Should().Be(0xCE);
            rebuiltD002.FloorInfos[0].MysteryHouseChance.Should().Be(0xCD);
            rebuiltD002.FloorInfos[0].MysteryHouseSize.Should().Be(0xCC);
            rebuiltD002.FloorInfos[0].InvitationIndex.Should().Be(0xCB);
            rebuiltD002.FloorInfos[0].MonsterHouseChance.Should().Be(0xCA);
            rebuiltD002.FloorInfos[0].Byte56.Should().Be(0xC9);
            rebuiltD002.FloorInfos[0].Byte57.Should().Be(0xC8);
            rebuiltD002.FloorInfos[0].Byte58.Should().Be(0xC7);
            rebuiltD002.FloorInfos[0].Weather.Should().Be((DungeonStatusIndex)0xC6);
        }
    }
}
