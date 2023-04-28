using Stok;
using Stok.ORM;
using Stok.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok.WFUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvListe.DataSource = Stoklar.Select();
        }
        public void StokListele()
        {
            dgvListe.DataSource = Stoklar.Select();
            dgvListe.Columns[0].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Stok.ORM.Stok s = new Stok.ORM.Stok();
            s.StokModeli = txtModel.Text;
            s.StokTarih=DateTime.Parse(txtTarih.Text);
            s.StokSeriNo = Convert.ToInt32(txtSeri.Text);
            s.StokAdedi =Convert.ToInt32( txtAdet.Text);
            s.KayitYapan = txtKayit.Text;
            bool sonuc = Stoklar.Insert(s);
            if (sonuc)
            {
                MessageBox.Show("Başarılı Oldu.");
                StokListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
            txtAdet.Text = string.Empty;
            txtKayit.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtSeri.Text = string.Empty;
            txtTarih.Text = string.Empty;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Stok.ORM.Stok s = new Stok.ORM.Stok();
            s.StokID = (int)(dgvListe.CurrentRow.Cells["StokID"].Value);
            s.StokModeli = txtModel.Text;
            s.StokSeriNo = Convert.ToInt32(txtSeri.Text);
            s.StokAdedi = Convert.ToInt32(txtAdet.Text);
            s.KayitYapan = txtKayit.Text;
            bool sonuc = Stoklar.Update(s);
            if (sonuc)
            {
                MessageBox.Show("Başarılı Oldu.");
                StokListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
            txtAdet.Text = string.Empty;
            txtKayit.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtSeri.Text = string.Empty;
            txtTarih.Text = string.Empty;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Stok.ORM.Stok s = new Stok.ORM.Stok();
            s.StokID = (int)(dgvListe.CurrentRow.Cells["StokID"].Value);
            bool sonuc = Stoklar.Delete(s);
            if (sonuc)
            {
                MessageBox.Show("Başarılı Oldu.");
                StokListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
            txtAdet.Text = string.Empty;
            txtKayit.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtSeri.Text = string.Empty;
            txtTarih.Text = string.Empty;
        }

        private void dgvListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModel.Text = dgvListe.CurrentRow.Cells[1].Value.ToString();
            txtSeri.Text = dgvListe.CurrentRow.Cells[2].Value.ToString();
            txtAdet.Text = dgvListe.CurrentRow.Cells[3].Value.ToString();
            txtKayit.Text = dgvListe.CurrentRow.Cells[5].Value.ToString();
        }
    }
    }
