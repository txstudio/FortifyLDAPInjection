//using Microsoft.Security.Application;
using System;
using System.DirectoryServices;

namespace FortifyLDAPInjection
{
    class Program
    {
        const string entryPath = "LDAP://<domain>";

        static void Main(string[] args)
        {
            string _account;
            string _filter;

            DirectoryEntry _entry;
            DirectorySearcher _searcher;

            _entry = new DirectoryEntry();
            _entry.Path = entryPath;

            _account = args[0];

            _filter = "(&(objectCategory=user)(CN=" + _account + "))";
            //_filter = Encoder.LdapFilterEncode(_filter);

            _searcher = new DirectorySearcher();

            _searcher.Filter = _filter;
            _searcher.SearchScope = SearchScope.Subtree;
            _searcher.SearchRoot = _entry;

            var items = _searcher.FindAll();
            var item = items[0];


            Console.WriteLine(items.Count);

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
