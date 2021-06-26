using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace JobManagement.API.Models.Security
{
    public class Security
    {
        private string _sCadena;
        private string _userKey;
        private int _temp;
        private short _a;
        private short _b;
        private object _j;
        private short _i;
        public string[] ArrContenido;
        public int CLinea;
        public string Cadena;
        public int Token;
        public string SDbms;
        public string SDriver;
        public string SUser;
        public string SPass;
        public string SServer;
        public long TypeCon;
        public string SCatalog;
        public string SpSec;
        public string SiSec;
        public string SDns;
        public string ConexionDefault;
        public string ConexionActiva;

        public Security() => this.ArrContenido = new string[10];

        public Security(string clave)
        {
            this.ArrContenido = new string[10];
         
        }

        public string Desencriptar(string line, string key)
        {
            this._sCadena = "";
            this._temp = 0;
            this._j = (object)0;
            line = Strings.Trim(line);
            short[] numArray1 = new short[checked(Strings.Len(key) + 1)];
            short num1 = checked((short)Strings.Len(key));
            this._a = (short)1;
            while ((int)this._a <= (int)num1)
            {
                numArray1[(int)this._a] = checked((short)Strings.Asc(Strings.Mid(key, (int)this._a, 1)));
                checked { ++this._a; }
            }
            short[] numArray2 = new short[checked(Strings.Len(line) + 1)];
            short num2 = checked((short)Strings.Len(line));
            this._b = (short)1;
            while ((int)this._b <= (int)num2)
            {
                numArray2[(int)this._b] = checked((short)Strings.Asc(Strings.Mid(line, (int)this._b, 1)));
                checked { ++this._b; }
            }
            short num3 = checked((short)Strings.Len(line));
            this._i = (short)1;
            while ((int)this._i <= (int)num3)
            {
                this._j = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.ConditionalCompareObjectGreaterEqual(Operators.AddObject(this._j, (object)1), (object)Strings.Len(key), false), (object)1, Operators.AddObject(this._j, (object)1)));
                this._temp = (int)checked((short)unchecked((int)numArray2[(int)this._i] - (int)numArray1[Conversions.ToInteger(this._j)]));
                if (this._temp < 0)
                    checked { this._temp += (int)byte.MaxValue; }
                this._sCadena += Conversions.ToString(Strings.Chr(this._temp));
                checked { ++this._i; }
            }
            return this._sCadena;
        }
        public string SetConnection(string filename, string UserK)
        {
            string conexionActiva = "";
            if (File.Exists(filename))
            {
                this.CLinea = 0;
                this._userKey = "Codigo Encriptado Aleatorio de Prueba Proteccion contra Hackers y Virus";
                FileSystem.FileOpen(1, filename, OpenMode.Input);
                while (!FileSystem.EOF(1))
                {
                    this.Cadena = FileSystem.LineInput(1);
                    checked { ++this.CLinea; }
                    this.ArrContenido[this.CLinea] = this.Cadena;
                }
                if (this.CLinea == 3)
                {
                    this.SDriver = this.Desencriptar(Strings.Replace(this.ArrContenido[1], ";", ""), this._userKey) + ";";
                    this.SDns = this.Desencriptar(Strings.Replace(this.ArrContenido[2], ";", ""), this._userKey) + ";";
                    this.SpSec = this.Desencriptar(Strings.Replace(this.ArrContenido[3], ";", ""), this._userKey) + ";";
                    this.ConexionActiva = this.SDriver + this.SDns + this.SpSec;
                }
                else if (this.CLinea == 5)
                {
                    this.SDriver = this.Desencriptar(Strings.Replace(this.ArrContenido[1], ";", ""), this._userKey) + ";";
                    this.SiSec = this.Desencriptar(Strings.Replace(this.ArrContenido[2], ";", ""), this._userKey) + ";";
                    this.SpSec = this.Desencriptar(Strings.Replace(this.ArrContenido[3], ";", ""), this._userKey) + ";";
                    this.SCatalog = "Initial Catalog=JOB_MANAGEMENT;";
                    this.SDns = this.Desencriptar(Strings.Replace(this.ArrContenido[5], ";", ""), this._userKey) + ";";
                    this.ConexionActiva = this.SDriver + this.SiSec + this.SpSec + this.SCatalog + this.SDns;
                    this.ConexionDefault = this.SDriver + this.SiSec + this.SpSec + "Master" + this.SDns;
                }
                else if (this.CLinea == 6)
                {
                    this.SDriver = this.Desencriptar(Strings.Replace(this.ArrContenido[1], ";", ""), this._userKey) + ";";
                    this.SPass = this.Desencriptar(Strings.Replace(this.ArrContenido[2], ";", ""), this._userKey) + ";";
                    this.SpSec = this.Desencriptar(Strings.Replace(this.ArrContenido[3], ";", ""), this._userKey) + ";";
                    this.SUser = this.Desencriptar(Strings.Replace(this.ArrContenido[4], ";", ""), this._userKey) + ";";
                    this.SCatalog = this.Desencriptar(Strings.Replace(this.ArrContenido[5], ";", ""), this._userKey) + ";";
                    this.SDns = this.Desencriptar(Strings.Replace(this.ArrContenido[6], ";", ""), this._userKey) + ";";
                    this.ConexionActiva = this.SDriver + this.SPass + this.SpSec + this.SUser + this.SCatalog + this.SDns;
                    this.ConexionDefault = this.SDriver + this.SPass + this.SpSec + this.SUser + "Master" + this.SDns;
                }
                this.Token = 0;
                FileSystem.FileClose(1);
                conexionActiva = this.ConexionActiva;
            }
            else
                this.Token = 1;
            return conexionActiva;
        }

    }
}