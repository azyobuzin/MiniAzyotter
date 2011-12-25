using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using XSpect.Yacq;

static class YacqBootstrapper {
	[STAThread]
	public static void Main(string[] args) {
		var scriptFile = "EntryPoint.yacq";
		
		if (args.Any()) scriptFile = args[0];
		
		foreach (var exp in YacqServices.ParseAll(new SymbolTable(), File.ReadAllText(scriptFile))) {
			Expression.Lambda(exp).Compile().DynamicInvoke();
		}
	}
}