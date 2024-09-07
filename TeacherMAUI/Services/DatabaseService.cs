﻿using SQLite;
using TeacherMAUI.Models;

namespace TeacherMAUI.Services
{
    public class DatabaseService
    {

        readonly SQLiteAsyncConnection _database; //establishes database connection
        public DatabaseService(string dbPath)
        {
            bool dbExists = File.Exists(dbPath); //boolean that checks if there is a file that exists in dbPath
            _database = new SQLiteAsyncConnection(dbPath);// establishes new database connection to dbpath


            if (!dbExists) //checks if a database DOESNT exist
            {
                Task.Run(async () =>
                {

                    CreateTables(_database); //creates tables when db does not exist
                });

            }


        }

        private static async void CreateTables(SQLiteAsyncConnection dbConnection)
        {
            await dbConnection.CreateTableAsync<Lesson>();//creates table for Lesson


            await dbConnection.CreateTableAsync<Tmima>();//creates table for Tmima

            await dbConnection.CreateTableAsync<Efhmeria>();// creates table for Efhmeria

            await dbConnection.CreateTableAsync<Exei>(); //creates table for Exei



        }

        public Task<List<Lesson>> GetLessonsAsync() //establishing getlist for ui feedback for table lesson
        {
            return _database.Table<Lesson>().ToListAsync();
        }

        public Task<int> SaveLessonAsync(Lesson lesson)  //establishing save for insertion of row in table lesson
        {
            return _database.InsertAsync(lesson);
        }
        public Task<List<Tmima>> GetTmimasAsync()  //establishing getlist for ui feedback for table tmima
        {
            return _database.Table<Tmima>().ToListAsync();
        }

        public Task<int> SaveTmimaAsync(Tmima tmima) //establishing save for insertion of row in table tmima
        {
            return _database.InsertAsync(tmima);
        }

        public Task<List<Efhmeria>> GetEfhmeriasAsync()  //establishing getlist for ui feedback for table efhmeria
        {
            return _database.Table<Efhmeria>().ToListAsync();
        }

        public Task<int> SaveEfhmeriaAsync(Efhmeria efhmeria) //establishing save for insertion of row in table efhmeria
        {
            if (efhmeria.Id != 0)
            {
                return _database.UpdateAsync(efhmeria);
            }
            else
            {
                return _database.InsertAsync(efhmeria);
            }
        }
        public Task<List<Exei>> GetExeisAsync()  //establishing getlist for ui feedback for table efhmeria
        {
            return _database.Table<Exei>().ToListAsync();
        }

        public Task<int> DeleteEfhmeriaAsync(Efhmeria efhmeria)//establishing delete for removing row in the table EEfhmeria
        {
            return _database.DeleteAsync(efhmeria);
        }

        public Task<int> SaveExeiAsync(Exei exei) //establishing save and update for insertion of row in table efhmeria
        {
            if (exei.Id != 0)
            {
                return _database.UpdateAsync(exei);
            }
            else
            {
                return _database.InsertAsync(exei);
            }
        }
        public Task<int> DeleteExeiAsync(Exei exei)//establishing delete for removing row in the table Exei
        {
            return _database.DeleteAsync(exei);
        }


    }


}
