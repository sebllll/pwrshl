using System.Collections.ObjectModel;
using System.Management.Automation;



using (PowerShell ps = PowerShell.Create())
{
    var pid = PowerShellHelpers.Run("test");

    Console.WriteLine(pid);

}


public class PowerShellHelpers
{
    public static int? Run(string input)
    {
        Collection<PSObject> ps_output;

        using (PowerShell ps = PowerShell.Create())
        {
            ps.AddScript(@"$process = start-process C:\vvvv\vvvv_gamma_5.3-0432-gebaa53fdbe\vvvv.exe --allowmultiple -passthru; $process.id");

            ps_output = ps.Invoke();
        }

        return Int32.Parse(ps_output.FirstOrDefault().ToString());
    }
}