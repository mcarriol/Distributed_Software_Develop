using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Reflection;
//using XMLFile1.xml;

//using System.SystemException;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlNode node;

            System.Reflection.Assembly asm = Assembly.GetExecutingAssembly();
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(asm.GetManifestResourceStream("hi.XMLFile1.xml"));
            doc.Load(reader);
            node = doc.DocumentElement;
            Console.WriteLine(node.Value);
            /*
       XmlDocument doc = new XmlDocument();
        XmlNode node;
        //XmlDocument doc = new XmlDocument();
            doc.Load("c:\\XMLFile1.xml");
            node = doc.DocumentElement;
            Console.WriteLine(node.Value);*/



        }
    }
}
