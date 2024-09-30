using System.IO;

namespace ComeBackLuci.Mirlif
{
    public static class FO_Credit
    {
        public static void LuciBatch(string pathDir)
        {
            if (!Directory.Exists(pathDir)) return;

            using (StreamWriter hl = new StreamWriter(Path.Combine(pathDir, "ComeBackLuci.bat")))
            {
                hl.WriteLine("::M3RFR3T | ComeBackLuci");
                hl.WriteLine("@echo off");
                hl.WriteLine("title github.com/RazeLeakers");
                hl.WriteLine("mode 48,31");
                hl.WriteLine(":luci");
                hl.WriteLine("timeout /t 1 > nul");
                hl.WriteLine("color C");
                hl.WriteLine(@"echo ==============================================");
                hl.WriteLine(@"echo "" $$$$$$\                                    """);
                hl.WriteLine(@"echo ""$$  __$$\                                   """);
                hl.WriteLine(@"echo ""$$ /  \__| $$$$$$\  $$$$$$\$$$$\   $$$$$$\  """);
                hl.WriteLine(@"echo ""$$ |      $$  __$$\ $$  _$$  _$$\ $$  __$$\ """);
                hl.WriteLine(@"echo ""$$ |      $$ /  $$ |$$ / $$ / $$ |$$$$$$$$ |""");
                hl.WriteLine(@"echo ""$$ |  $$\ $$ |  $$ |$$ | $$ | $$ |$$   ____|""");
                hl.WriteLine(@"echo ""\$$$$$$  |\$$$$$$  |$$ | $$ | $$ |\$$$$$$$\ """);
                hl.WriteLine(@"echo "" \______/  \______/ \__| \__| \__| \_______|""");
                hl.WriteLine(@"echo ""                                            """);
                hl.WriteLine("timeout /t 1 > nul");
                hl.WriteLine("color A");
                hl.WriteLine(@"echo ""                                            """);
                hl.WriteLine(@"echo ""$$$$$$$\                      $$\           """);
                hl.WriteLine(@"echo ""$$  __$$\                     $$ |          """);
                hl.WriteLine(@"echo ""$$ |  $$ | $$$$$$\   $$$$$$$\ $$ |  $$\     """);
                hl.WriteLine(@"echo ""$$$$$$$\ | \____$$\ $$  _____|$$ | $$  |    """);
                hl.WriteLine(@"echo ""$$  __$$\  $$$$$$$ |$$ /      $$$$$$  /     """);
                hl.WriteLine(@"echo ""$$ |  $$ |$$  __$$ |$$ |      $$  _$$<      """);
                hl.WriteLine(@"echo ""$$$$$$$  |\$$$$$$$ |\$$$$$$$\ $$ | \$$\     """);
                hl.WriteLine(@"echo ""\_______/  \_______| \_______|\__|  \__|    """);
                hl.WriteLine(@"echo ""                                            """);
                hl.WriteLine("timeout /t 1 > nul");
                hl.WriteLine("color 9");
                hl.WriteLine(@"echo ""                                            """);
                hl.WriteLine(@"echo ""$$\                          $$\            """);
                hl.WriteLine(@"echo ""$$ |                         \__|           """);
                hl.WriteLine(@"echo ""$$ |     $$\   $$\  $$$$$$$\ $$\            """);
                hl.WriteLine(@"echo ""$$ |     $$ |  $$ |$$  _____|$$ |           """);
                hl.WriteLine(@"echo ""$$ |     $$ |  $$ |$$ /      $$ |           """);
                hl.WriteLine(@"echo ""$$ |     $$ |  $$ |$$ |      $$ |           """);
                hl.WriteLine(@"echo ""$$$$$$$$\\$$$$$$  |\$$$$$$$\ $$ |           """);
                hl.WriteLine(@"echo ""\________|\______/  \_______|\__|           """);
                hl.WriteLine(@"echo ==============================================");
                hl.WriteLine("timeout /t 1 > nul");
                hl.WriteLine("cls");
                hl.WriteLine("goto luci");
            }
        }
    }
}
