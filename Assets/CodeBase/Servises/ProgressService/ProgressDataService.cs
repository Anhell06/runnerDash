using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Servises.ProgressService
{
    class ProgressDataService : IProgressDataServise
    {
        public ColLectebleItemData CollectebleItemData { get; set; }
        public LevelProgressData LevelProgressData { get; set; }

        public void UpdateCollectebelItem(int life, int shield)
        {
            CollectebleItemData.Life = life;
            CollectebleItemData.Shield = shield;
        }
    }
}
