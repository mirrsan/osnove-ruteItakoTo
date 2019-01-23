using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using frrstBildStudioProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace frrstBildStudioProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OsnoveController : Controller
    {
        // citanje podataka sa fajla pomocu StreamReadera
        [HttpGet("[action]/{path}")]
        public string CitanjeFjjla(string path)
        {
            using (StreamReader reader = System.IO.File.OpenText(@"" + path))
            {
                string s = "";

                while ((s = reader.ReadLine()) != null)
                {
                    return s;
                }

                return "Nista brate nema";
            }
        }
        // enumeracija
        enum Meseci_ { Januar, Februar, Mart, April, Maj, Jun, Jul, Avgust, Septembar, Oktobar, Novembar, Decembar }

        // upotreba enumeracije i switch-a
        [HttpGet("[action]/{mesec}:int")]
        public string Meseci(int mesec)
        {
            switch (mesec)
            {
                case 1:
                    return Meseci_.Januar.ToString();
                    break;
                case 2:
                    return Meseci_.Februar.ToString();
                    break;
                case 3:
                    return Meseci_.Mart.ToString();
                    break;
                case 4:
                    return Meseci_.April.ToString();
                    break;
                case 5:
                    return Meseci_.Maj.ToString();
                    break;
                case 6:
                    return Meseci_.Jun.ToString();
                    break;
                case 7:
                    return Meseci_.Jul.ToString();
                    break;
                case 8:
                    return Meseci_.Avgust.ToString();
                    break;
                case 9:
                    return Meseci_.Septembar.ToString();
                    break;
                case 10:
                    return Meseci_.Oktobar.ToString();
                    break;
                case 11:
                    return Meseci_.Novembar.ToString();
                    break;
                case 12:
                    return Meseci_.Decembar.ToString();
                    break;
                default:
                    return "Nema vise od 12 meseci ee";
                    break;
            }

            return null;
        }
        // serializacija
        [HttpGet("[action]/{imeFajla}/{id}/{name}")]
        public string Serializablee(string imeFajla, int id, string name)
        {
            Primeri pr = new Primeri(id, name);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\\Users\\Bild324\\Desktop" + imeFajla + ".txt", FileMode.Create, FileAccess.Write); 

            formatter.Serialize(stream, pr);
            stream.Close();
            return "moze";
        }

        // hello world
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello World";
        }

        // ispis broja
        [HttpGet("[action]/{broj}")]
        public int VracaBroj(int broj)
        {
            return broj;
        }

        // ispis striga i broja
        [HttpGet("[action]/{broj}:int/poruka")]
        public string IspisStringaBroja(int broj, string poruka)
        {
                return broj + ". " + poruka;
        }

        // primana if-else
        [HttpGet("[action]/{broj}")]
        public string VeceManje(int broj)
        {
            if (broj < 10)
            {
                return "Broj je manji od 10";
            }
            else if (broj > 10)
            {
                return "Broj je veci od 10";
            }
            else return "Broj je jednak 10";
        }

        // int nizz
        [HttpGet("[action]/{br1}/{br2}/{br3}")]
        public string Nizz(int br1, int br2, int br3)
        {
            int[] niz = new int[3];
            niz[0] = br1;
            niz[1] = br2;
            niz[2] = br3;

            return niz[0] + " " + niz[1] + " " + niz[2];
        }

        // primena ArrayList-e
        [HttpGet("[action]/{br}/{nesto}")]
        public string NizArray(string nesto, int br)
        {
            ArrayList list = new ArrayList();

            list.Add(br);
            list.Add(nesto);

            return $"{br}. {nesto}";
        }
        
    }


}
