//using Stok.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stok.ORM;


namespace Stok.ORM.Facade
{
    public class Stoklar
    {
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Stok", Tools.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Insert(Stok s)
        {
            // SqlCommand komut = new SqlCommand("UrunEkle", baglanti);//sql de procedure olursa
            //komut.CommandType = CommandType.StoredProcedure;//sql de procedure olursa

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "insert stok (StokModeli,StokSeriNo,StokAdedi,KayitYapan,StokTarih) values (@modeli,@serino,@adet,@kayit,@tarih)";
            komut.Parameters.AddWithValue("@modeli", s.StokModeli);
            komut.Parameters.AddWithValue("@serino", s.StokSeriNo);
            komut.Parameters.AddWithValue("@adet", s.StokAdedi);
            komut.Parameters.AddWithValue("@tarih", s.StokTarih);
            komut.Parameters.AddWithValue("@kayit", s.KayitYapan);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);

        }
        public static bool Update(Stok s)
        {

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "UPDATE stok SET StokModeli = @modeli, StokSeriNo = @serino , StokAdedi= @adet , KayitYapan = @kayit WHERE StokID = @id";
            komut.Parameters.AddWithValue("@modeli", s.StokModeli);
            komut.Parameters.AddWithValue("@serino", s.StokSeriNo);
            komut.Parameters.AddWithValue("@adet", s.StokAdedi);
            //komut.Parameters.AddWithValue("@tarih", s.StokTarih);
            komut.Parameters.AddWithValue("@kayit", s.KayitYapan);
            komut.Parameters.AddWithValue("@id", s.StokID);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);
        }
        public static bool Delete(Stok s)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "DELETE stok WHERE StokID = @id";
            komut.Parameters.AddWithValue("@id", s.StokID);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);
        }

    }
}
