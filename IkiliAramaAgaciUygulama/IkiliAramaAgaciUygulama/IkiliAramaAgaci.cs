using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IkiliAramaAgaciUygulama
{
    public  class IkiliAramaAgaci
    {
        public IkiliAramaAgacDugumu kok;
        public class IkiliAramaAgacDugumu
        {
            public int veri;
            public IkiliAramaAgacDugumu sol;
            public IkiliAramaAgacDugumu sag;

            public IkiliAramaAgacDugumu(int veri)
            {
                this.veri = veri;
                this.sol = null;
                this.sag = null;
            }
        }
        public IkiliAramaAgaci()
        {
            kok = null;
        }
        public void Ekle(int veri)
        {
            kok = EkleRec(kok, veri);
        }
        private IkiliAramaAgacDugumu EkleRec(IkiliAramaAgacDugumu dugum, int veri)
        {
            if (dugum == null)
            {
                dugum = new IkiliAramaAgacDugumu(veri);
                return dugum;
            }

            if (veri < dugum.veri)
            {
                dugum.sol = EkleRec(dugum.sol, veri);
            }
            else if (veri > dugum.veri)
            {
                dugum.sag= EkleRec(dugum.sag, veri);
            }

            return dugum;
        }
        private IkiliAramaAgacDugumu MinDeger(IkiliAramaAgacDugumu dugum)
        {
            IkiliAramaAgacDugumu tempSol = dugum;
            while (tempSol.sol != null)
            {
                tempSol = tempSol.sol;
            }
            return tempSol;
        }
        private IkiliAramaAgacDugumu MaxDeger(IkiliAramaAgacDugumu dugum)
        {
            IkiliAramaAgacDugumu tempSag = dugum;
            while (tempSag.sag != null)
            {
                tempSag = tempSag.sag;
            }
            return tempSag;
        }
        public IkiliAramaAgacDugumu Arama(int veri)
        {
            return AramaRec(kok, veri);
        }
        private IkiliAramaAgacDugumu AramaRec(IkiliAramaAgacDugumu dugum, int veri)
        {
            if (dugum == null) {
                return null;
            }
            if (veri == dugum.veri) {
                return dugum;
            }
            if (veri < dugum.veri) {
                return AramaRec(dugum.sol, veri);
            }
            return AramaRec(dugum.sag, veri);
        }
        public IkiliAramaAgacDugumu Successor(IkiliAramaAgacDugumu dugum)
        {
            // Eğer düğümün sağ alt ağacı varsa, successor o ağacın en küçük düğümüdür.
            if (dugum.sag != null)
            {
                return MinDeger(dugum.sag);
            }

            IkiliAramaAgacDugumu successor = null;
            IkiliAramaAgacDugumu ancestor = kok;

            while (ancestor != dugum)
            {
                if (dugum.veri < ancestor.veri)
                {
                    successor = ancestor;
                    ancestor = ancestor.sol;
                }
                else
                {
                    ancestor = ancestor.sag;
                }
            }

            if (successor != null)
            {
                return successor;
            }
            else
            {
                return null;
            }
        }
        public void InOrder()
        {
            InOrderRec(kok);
        }
        private void InOrderRec(IkiliAramaAgacDugumu kok)
        {
            if (kok != null)
            {
                InOrderRec(kok.sol);
                Debug.Write(kok.veri + " ");
                InOrderRec(kok.sag);
            }
        }
        public void PreOrder()
        {
            PreOrderRec(kok);
        }
        private void PreOrderRec(IkiliAramaAgacDugumu kok)
        {
            if (kok != null)
            {
                Debug.Write(kok.veri + " ");
                PreOrderRec(kok.sol);
                PreOrderRec(kok.sag);
            }
        }
        public void PostOrder()
        {
            PostOrderRec(kok);
        }
        private void PostOrderRec(IkiliAramaAgacDugumu kok)
        {
            if (kok != null)
            {
                PostOrderRec(kok.sol);
                PostOrderRec(kok.sag);
                Debug.Write(kok.veri + " ");
            }
        }

        public void Sil(int veri)
        {
            kok = SilRec(kok, veri);
        }
        private IkiliAramaAgacDugumu SilRec(IkiliAramaAgacDugumu dugum, int veri)
        {
            if (dugum == null)
            {
                return dugum;
            }

            if (veri < dugum.veri)
            {
                dugum.sol = SilRec(dugum.sol, veri);
            }
            else if (veri > dugum.veri)
            {
                dugum.sag = SilRec(dugum.sag, veri);
            }
            else
            {
                // Düğümü silme işlemi
                if (dugum.sol == null)
                {
                    return dugum.sag;
                }
                else if (dugum.sag == null)
                {
                    return dugum.sol;
                }

                // İki çocuğu olan düğümü silme işlemi
                dugum.veri = MinDeger(dugum.sag).veri;

                dugum.sag = SilRec(dugum.sag, dugum.veri);
            }

            return dugum;
        }
    }
}
