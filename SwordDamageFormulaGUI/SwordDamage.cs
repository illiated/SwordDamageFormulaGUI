﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SwordDamageFormulaGUI

{
    internal class SwordDamage
    {
        public const int BASE_DAMAGE = 3; //private this?
        public const int FLAME_DAMAGE = 2; //private this?

        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlameDamage = 0;
        public int Damage;

        public void CalculateDamage()// private this?
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlameDamage;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1M;
            }
            CalculateDamage();
            Debug.WriteLine($"SetMagic finished: {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;    
            }
            Debug.WriteLine($"SetFlaming finished: {Damage} (roll: {Roll})");
        }

    }
}
