using System;

Console.WriteLine("Hello World!");

var table = Simple.DBF.Reader.Open("db.dbf", encoding: System.Text.Encoding.UTF8);
table = table;

var buildModelClass = table.ExportModelClassTemplate();

// Use this string to create a model class
buildModelClass = buildModelClass;

