using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine; // not mandatory I just made it on the Unity Engine




namespace EasySave
{
    public class DataBase
    {
        public static string unityPath = Application.dataPath + "/Saves/";
        public string path;
        public List<DataBaseUnit> data = new List<DataBaseUnit>();
        public DataBase(string name, string path)
        {
                
            this.path = path;
           

            if (File.Exists(path))
            {
                Syncronize();
            }
            else if(path != null)
            {
                using (StreamWriter sw = File.CreateText(path)) { }
            }
        }
        /// <summary>
        /// Return a Data based on its name in the data list of the database.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataBaseUnit Find(string name)
        {
            DataBaseUnit tofind = null;
            foreach (DataBaseUnit unit in data)
            {
                if (unit.name == name)
                {
                    tofind = unit;
                    break;
                }
                break;
            }
            return tofind;
        }
        /// <summary>
        /// Save a native type variable by creating Key-value variable in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public void Save(string name, string content)
        {
            Write(name, content);
            Syncronize();
        }
        public void Save(string name, float content)
        {
            Write(name, content.ToString());
            Syncronize();

        }
        public void Save(string name, int content)
        {
            Write(name, content.ToString());
            Syncronize();

        }
        public void Save(string name, bool content)
        {
            Write(name, content.ToString());
            Syncronize();
        }

        /// <summary>
        /// Find a variable stored in the database by its key/name and return it as a string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string LoadAsString(string name)
        {
            return Find(name).content;
        }
        /// <summary>
        /// Find a variable stored in the database by its key/name and return it as a float.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public float LoadAsFloat(string name)
        {
            return float.Parse(Find(name).content);
        }
        /// <summary>
        /// Find a variable stored in the database by its key/name and return it as an integer.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int LoadAsInt(string name)
        {
            return int.Parse(Find(name).content);
        }
        /// <summary>
        /// Find a variable stored in the database by its key/name and return it as a boolean.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool LoadAsBool(string name)
        {
            return bool.Parse(Find(name).content);
        }

        private void Write(string name, string content)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(name + ":" + content);
            }
        }
        private void Syncronize()
        {
            data.Clear();
            foreach (string line in File.ReadAllLines(path))
            {
                string[] content = line.Split(":");
                data.Add(new DataBaseUnit(content[0], content[1]));
            }
        }
    }

    public class DataBaseUnit
    {
        public string content;
        public string name;
        public DataBaseUnit(string name, string content)
        {
            this.content = content;
            this.name = name;
        }
    }
}

