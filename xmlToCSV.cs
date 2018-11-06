using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections;


class xmlToCSV {
	/* 
	Badly made garbage to rip the card names out of Cockatrice's cards.xml file and make a comma 
	seperated values file out of them.
	Give it the location of the cards.xml file, then the desired location of the cards file
	*/
	public static void Main(string[] args) {
		Console.WriteLine("Turning " + args[0] + " into " + args[1]);
		string inputFile = args[0];
		string output = args[1];
		XElement cardsDoc = XElement.Load(args[0]);
		 
		//This catches set names too, should be more specific
		IEnumerable cardNames = 
			from el in cardsDoc.Descendants("name")
			select (string)el;
			
		foreach (string element in cardNames) {
			Console.WriteLine("\"" + element + "\"," );
			string s = ("\"" + element + "\",\n" );
			File.AppendAllText(output, s);
		}
	}
}