using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System;


public class Connection : MonoBehaviour
{
    public static int DBHP;
    public static int DBPotions;
    public static int DBInvi;
    public static int DBLives;
    public static DateTime Boslaskil;
    public static int [] DBEnemiesSpawn = new int[4];
    public static string [,] DBEnemies=new string[6,4];


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public static void DBEnemyKill()
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";
            print("connection up");
            using (SqlConnection connection = new SqlConnection(conn))   //esta sentencia permite que connection se destruya al salir de bloque , no hay que usar connection.close() en otras palabras
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("dbo.GruntKilled", connection))
                { //https://stackoverflow.com/questions/293311/whats-the-best-method-to-pass-parameters-to-sqlcommand
                    command.CommandType = System.Data.CommandType.StoredProcedure; //si no le ponen esto no funciona
                    command.ExecuteNonQuery();
                    print("stored procedure");

                }
            }
        }
        catch (SqlException e)
        {
            print(e.ToString());
        }
    }*/
    public static void LoadPlayer()
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))   //esta sentencia permite que connection se destruya al salir de bloque , no hay que usar connection.close() en otras palabras
            {
                connection.Open();

                string sql = "SELECT Hp,Lives FROM PlayerView WHERE PlayerView.PlayerID="+PlayerHealth.identifier+";"; 

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //command.Parameters.Add()
                   
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                             DBHP=reader.GetInt32(0);

                            DBLives = reader.GetInt32(1);
                        }
                    }
                }
            }
            
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static void LoadPlayerItems()
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))   //esta sentencia permite que connection se destruya al salir de bloque , no hay que usar connection.close() en otras palabras
            {
                connection.Open();
                
                string sql = "SELECT Quantity FROM PlayerItemsView WHERE PlayerItemsView.F_PlayerID=" + PlayerHealth.identifier + ";";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                 
                    using (SqlDataReader reader1 = command.ExecuteReader())
                    {
                        
                        int[] itesm = new int[2];
                        int coumt = 0;
                        while (reader1.Read())
                        {
                            itesm[coumt] = reader1.GetInt32(0);
                            coumt++;
                        }
                        DBPotions = itesm[0];
                        DBInvi = itesm[1];
                    }
                }
            }

        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }

       
    }

    public static void EnemiesInfo()
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))   //esta sentencia permite que connection se destruya al salir de bloque , no hay que usar connection.close() en otras palabras
            {
                connection.Open();

                string sql = "SELECT * FROM EnemyListView";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader1 = command.ExecuteReader())
                    {
                        string[,] enemis = new string[3,4];
                        int coumt = 0;
                        while (reader1.Read())
                        {
                            enemis[coumt,0 ] = reader1.GetInt32(0).ToString();
                            print(enemis[coumt, 0]);
                            enemis[coumt, 1] = reader1.GetString(1);
                            enemis[coumt, 2] = reader1.GetInt32(2).ToString();
                            enemis[coumt, 3] = reader1.GetString(3);

                            coumt++;
                        }
                        DBEnemies = enemis;
                    }
                }
            }

        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static void WorldEnemies()
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))   //esta sentencia permite que connection se destruya al salir de bloque , no hay que usar connection.close() en otras palabras
            {
                connection.Open();

                string sql = "SELECT * FROM WorldEnemies";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader1 = command.ExecuteReader())
                    {

                        int[] array = new int[4];
                        //string[,] enemis = new string[6, 4];
                        //int coumt = 0;
                        while (reader1.Read())
                        {

                            array[0] = reader1.GetInt32(0);
                            array[1] = reader1.GetInt32(1);
                            array[2] = reader1.GetInt32(2);
                            array[3] = reader1.GetInt32(3);

                            //coumt++;
                        }
                        DBEnemiesSpawn = array;
                    }
                }
            }

        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static void PlayerHpUpdater(int playid, int playhp)
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))
            { 
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.UpdatePlayerHp", connection))
                { 
                    command.CommandType = System.Data.CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@Hp", playhp);
                    command.Parameters.AddWithValue("@Id", playid);
                    command.ExecuteNonQuery();

                }
            }
        }
        catch (SqlException e)
        {
        }
    }

    public static void PlayerLivesUpdater(int playid, int playlivs)
    {
       
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.UpdatePlayerLives", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Live", playlivs);
                    command.Parameters.AddWithValue("@Id", playid);
                    command.ExecuteNonQuery();

                }
            }
        }
        catch (SqlException e)
        {
        }
    }

    public static void PlayerPotionUpdater(int playhp, int playid, int playpot, int sumi)
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";
            print("engaging proc");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                print("begining proc");
                using (SqlCommand command = new SqlCommand("dbo.PlayerPotion", connection))
                {
                    print("proc");
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Hp", playhp);
                    command.Parameters.AddWithValue("@Player", playid);
                    command.Parameters.AddWithValue("@Potions", playpot);
                    command.Parameters.AddWithValue("@Sum", sumi);
                    command.ExecuteNonQuery();

                }
            }
        }
        catch (SqlException e)
        {
        }
    }

    public static void PlayerInviUpdater()
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("dbo.InviUse", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
            }
        }
        catch (SqlException e)
        {
        }
    }

    public static void EnemyDeathUpdater(int enemid)
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.UpdateEnemy", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EnemyID", enemid);
                    command.ExecuteNonQuery();

                }
            }
        }
        catch (SqlException e)
        {
        }
    }

    public static void BossDeathUpdater(int bosid,DateTime bostim)
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.UpdateBoss", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BossID", bosid);
                    command.Parameters.AddWithValue("@Date", bostim);
                    command.ExecuteNonQuery();

                }
            }
        }
        catch (SqlException e)
        {
        }
    }

    public static void BossLastKillFunction(int bosid)
    {
        try
        {
            string conn = @"Data Source=127.0.0.1;Database=VG_BD_FinalDB;User ID=lolxd;Password=1234";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.BossLastKill", connection))
                {
                    command.Parameters.AddWithValue("@BossID", bosid);
                    command.ExecuteNonQuery();
                    Boslaskil = (DateTime)command.ExecuteScalar();
                }
            }
        }
        catch (SqlException e)
        {
        }
    }

}
