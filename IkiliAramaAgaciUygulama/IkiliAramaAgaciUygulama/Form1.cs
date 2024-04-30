using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IkiliAramaAgaciUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IkiliAramaAgaci tree = new IkiliAramaAgaci();

            // Örnek verileri ekleme
            tree.Ekle(50);
            tree.Ekle(30);
            tree.Ekle(20);
            tree.Ekle(40);
            tree.Ekle(35);
            tree.Ekle(70);
            tree.Ekle(60);
            tree.Ekle(80);

            Debug.WriteLine("Inorder gezinti:");
            tree.InOrder();
            Debug.WriteLine("");

            Debug.WriteLine("Preorder gezinti:");
            tree.PreOrder();
            Debug.WriteLine("");

            Debug.WriteLine("Postorder gezinti:");
            tree.PostOrder();
            Debug.WriteLine("");

            int key = 30;
            Debug.WriteLine($"Ağaçta {key} var mı? {tree.Arama(key)}");

            tree.Sil(30);
            Debug.WriteLine($"Ağaçta {key} var mı? {tree.Arama(key)}");

             key = 20;
            Debug.WriteLine($"{key}'in successorü {tree.Successor(tree.Arama(key)).veri}"); ;

            Debug.WriteLine("Inorder gezinti:");
            tree.InOrder();

            Debug.WriteLine("");
        }
    }
}
