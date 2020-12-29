using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XTB.CustomApiManager
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Custom API Manager"),
        ExportMetadata("Description", "Dataverse Custom API Management Tool"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAYAAACOEfKtAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAAB3RJTUUH5AwdASsQTIcWTQAAAAd0RVh0QXV0aG9yAKmuzEgAAAAMdEVYdERlc2NyaXB0aW9uABMJISMAAAAKdEVYdENvcHlyaWdodACsD8w6AAAADnRFWHRDcmVhdGlvbiB0aW1lADX3DwkAAAAJdEVYdFNvZnR3YXJlAF1w/zoAAAALdEVYdERpc2NsYWltZXIAt8C0jwAAAAh0RVh0V2FybmluZwDAG+aHAAAAB3RFWHRTb3VyY2UA9f+D6wAAAAh0RVh0Q29tbWVudAD2zJa/AAAABnRFWHRUaXRsZQCo7tInAAANsUlEQVR4nO1caZBc1XX+zj33vdfdM5oZ2QKBpBkNi1hiQtnggAFb2CljtOMAwji4MBVXgESAhEY4lcQ2IC/EFGNmQJSBKid2ih+EIdhopJFY4kgsRnJVqEqVsSEWSBoJjNhsSdPLe3c5+dHTKgHqnqWnpxuY70f/eO+775739V3POfeRiGAK44eqtwEfdEwJWCWmBKwSUwJWiSkBq4QeC3lR9yvzwHw+gU4EqEVIEeBrZdskQYHECyAHBLJDEW/ZsHLOjtGWptEsYy5YN3hs6PVqiL8YhHYdZgKlQwBUjeUNBIG3CWySMwANksgj1rsfbb5x7usjlRxRwIvu+sOpFu5eDtLzAYF3BuId8GFbPxKBFENxAACwprA18vban6/qfLFisUoCLrhz9zFM1KfTzZ91cQEibmKNblAQMThKweYOPi1Wlg/c1LmvHLfiJMLMXRxlPmuT/EdGPAAQcbBJAZxq+hwFek0lblkBF9y+8yRxbjkAwH/QJ4pxwBcbjMBfuqR374nlaGUFpBSfT8yzvDM1sO6DAe8MiNQsT+78cpyyAirgBB02BXAfna77PjgHHTWF5GleOUr5daCXFqUD2LgOs+3wjEhU/H9FfF1mfoFA6QAAtZTjlBVQoFQ91nmkNEgxvI3zHsgDAIlkVJBKiXcQbyfbIkjlnlqp3OSCFAME50z8C0XqMhPLaSaW0yDuK97Gj4LgSPFkm1VRizFt5WoJIgZA3hvTPSfT8c/3X4PDm9r65X0vbMq+Nu17SgXfJOKGWVY1iDOBQMwQb7ZaF976HvEAAH3LP2GsCW8VZ7YQMxplG9kYAtLwj6MHHl9zTK4c7fE1x+RE0QMANYp+DSLgsBoScMV9Z5HKvzu8TL3RIAIWwd6kRuJ4K+nJsGW0aAwBh9d3ztOFI1E1yYWHl6k3GkNACCAepOjrX+rZeVY51uKenWcJ4UqIL5ZpADTMMsY7Aw5SM2HNfYvufHl1xofPPdzVXgCAS7v3pLJIzlVBqlvpcKY3hXqbewgN0gKLcKYADsJPcjhtQ4HlgtL1AssFOtXSz0H0yUYSD2gwAQHAJXkEmbaMF2kvXfMi7UGmJeOSfD1NOyIaTkAAEGdARIcW00RkxU32Hnh0aEgBP0iYsElEcQAO0yDFEBGIM3CmUHRD1RGkGBykQByAiCDewSV5TJSjuHoBicBBGjbO7nLePEKCHRA0AThbCEtZR5G3cfWWjgNKR3A2jqWQ7QewHYSsAPMg+CsdZTqdyVe9nqxOQFJQHMDZuI/Zf7v/+s6XSreW3/NGU94WFnprepQOZ3ubVFXVWKF0BG/NqwqyKh2kNvWtODpbunfh3a/dp2zhe8zhpc4ZFNeV46ynOiMDeBs/F8X5FYeLBwB9K47ObljZ8bCH7xLvYtAk+vFIQbyLIX7NhpUdDx8uHgA8dv2sl8i/s8K6eFsxQWD8GLeApDS8KRiI3PfImhPeLMfTaV4vzj6uwxG3uYc/fZTXjgwOU3De/JexwfpynP6Vf/4GkdzrTcFU46StQkAFAWUNh1sr8fqvnpUH5BmdaobSIRQHh2IdR36uhtJhycM6fJFY6RCkyo84NDycKB1CR80gUb+u5BoDAC/x0wJkqxGw2knEQzdnR2QF/sEkuz8l1iwRyKmkuJmDDEQcxBrI8BjEQQo2ycfxwbe2Os/bSsUtyfZk6M0nvDfzdZCO3PBuhEiBdAAihrcxvLNDgLyU5A/2K/H/PpJZ4sIcqeqyo8YvoAgAn2Lzx1OB5rJdGAA2rjhuEMDa5fe80T3kktOUNcusd58npY5XHByjgxQEHiZ/cKd4+se3du98dNud5xzasz12Q8fzn+l+btkM3XGRs/FtOj3tOIKCswV4Z14XH79CwBZPtL6Zo9/0/f2Mkf9UAMxyioikqpmJxy2geAvmKONt8nUAT42mzPBgvh3A9vm3gFtaB8/xsH8p3pwnoBlE1DWwes4WoP19Zbd1nVMA8B+L79q7z8a5boK8Jd4+Sz74ZTS7/VePXDb2lkTCVyoOMtVE+sYvoEjRs87hVxb1Dv56YGXHfe/lLP3hK+0uFXSR4E3Rsnnguo7/Kd176hY4oOMZAM8svGv7tIDmfnz9DbN2jVTvxhvmbFl29+uXGNn99qaVZx88EmfRusEzydICIRzFBdPd/w/H73kvZ0nP4LWko+VCgmpOKpTNzlrUu+fHUdPHrk2y71R8gOIAAsl6Zx4E8KALml+kZH9GEX8BgquDTOsZ3hTgvd0r3v2eCE8SqQ1JrHeMNMiPFktveS0tLfE80bxEBF8kxfOU0nNUkILJ7X8ehPu9uP+WsDXHZugUEvkq6eBygsqMtCMJmz6GOPvOvQMr2//uSPer3ol4Z6A4aGIOv+Fc8lU22ZjASgRNHKa1LQyBALAO50CrOc7kvyAe39SBfWHxXXs2WxM/meYZv/3Fqrb9Y6n3yz27WnNITtZoOo+m+8UQ/jTArTpMAeKLCZNuCBymz3BJfh2Ds2KyHkCkdJQp2V4tJmQv7J0BiKA4yBCpDEQg4lHy3QmKvj6guDclpVpBdC6ROlfp8GaTHLwZaPv+WOo04OuisPVWIuZS2oeIh0ve3ai9KUCx1kSqFURFu7ydsJDAxHmkRSDOjuhoF+8gKDkYCNG0j3PBvHn6mKsjnB5ELRxn3x5RjHfXObGosztLYJM8IDj+gtsHjx1tqYvWvXUsBMcXy9Y3NlJ3f6A3BRDrTwUBll188UMj2nPxQ1Ae8TKl+VPe1t+9X3cBxVvoMMNEdMWBvzivbST+gTdebfPOfY2DDE9+ptb7UXcBSWl4G4NEftkW+hGXNW2xz8HTE97kK+6NJwv1tYAUOMjAFPY/kvHqX0phzEV37j5Xq2h6nvXzAJB29gxjkz9t6up49uGu9sL8n+76YfN+f3oQtVxik1xV/rxqUdcWyEEEGw+9FCh8qyTekt49nyDmn3hGX+ByLwQu94Jn9KmA/3XRupdPA4CnruqMveh/skn2RQ7G4iabeNRNQMUaPikUxJrvPHrD3N8BxQC6F/8DHWZOAZBmHU1nHU0HkNZh+iSy+vtfuuN/MwCwedXs/4Pz33FJPq+4fh2pPgKSguIQ4uWega7jHipdzrPqUkG0zJkCxBl4m8Db5FCASoWpZTqcflOJv/HGjj6BvZs4rOhjrCXqUiuHadg496TyfFvp2sLevQtBchNBHTGSV9xtECBq9cLeXQsPPcvGtzuTe1KF9UnamnQBOUzDx9k/KLhv93fNehsALux+dQ4TrdWpptZKETxvYwRRUwtT8N0v97w+FwD6u05+28N9yyW5vRxMvog1F5BIgcMMgkwbomlHFWdMcWv7V3VuA4AFd0nI2q/lMP1pG4/sB7VJFhxlzkyQfHf+T3dFALDphs7tHn6tiEPUchSCTBs4zExKt67p6FuMy+adxNkBG2d/pcOMd0k+n5md/UmJQ9jzN0rpK11SGN22TAQuzkOxvqJpf/IcgB8DwL6o499m5nZHRJyxSU4R6FwhWcQ6xbWMS9dMQNYRnEt2CuGmJD3tiSevnn6geGfGIc7inj2fI0W3EGv2ZvQvKeKgOFQkfPPinj2/2biq/ennr4EF5q4rcb54/x9bgkL2AmeTO1hHnbUSsSYCEjGcdzmQ7dp0fefPy/GEcF0QNs8cTdd9L7w1CKLmmSY/dB2Ap997v/iHTf/PRb27RZx9gIjTtTgaUZNBgsMI4s3GGdMwUJlpn7XxkCU1djNIKdjCkCWiZyrxjmqVjeLtRg6jMdcxGtREwOHPAWz72VWdFfsNCT0OIDuewX64TFY5+3gl3s+u6owhVHUGQjnUaJoiwGNEX1PeSg6AH9eJBSKA4BMEI/Z/ERRqdSyiJgKKtyDyZY+IlpBhniciqfFExUQEIpLSJGUPQx8Cy7xaub5qIqBLCgDxsgU9O0+qxBOSv2Ydpsd1It47sA7TovwVlWhL7951MkEtc0ltnK81EdA7Aw5TxyvSP1jau+/oI3GW9g5eo3R4mRAOpXaMBSIeQoDSweWLe/ZefeQ69h3tvbqNw9RxtTp5X7N1oDcFcBBd4kxh9uKewXsdwi0qKBSQ0J8R0deI9eUElZEq8gbFGigOm4Xxo8W9g2eB1ANKgt/GqpDRXn2eRK7lIH12LTP7ywso1Y26IgJYAw7Sn/EmfyZLkhXDHkoixWETAHhXfdKldwkUB03g8BvOJpc7JHHgSIGkicN04G1SVeZB8WXKa1FWQIL31Z4GEvEQUwApHZBSbcDEx2WBw+LSOmgiUk2HYsQT0vIEROVjouVboKID3hoQCFKtkN7VPtl8lHHpsYBAcDYBEcpmTZSdRMTLDhsPGXAdjtg3Cpjh4lzixJf9GFn5WdjprV7k1dK3pD6KUBxAxL/GsGXT98oKONA1+/dE6Bt+Ug3Ma3AMv7MC+jasPGEcLRAAdKrbxUPP6DD1rpTlDzuIGDpMwSa5rUTRHZW4FQUcWHH0vhD4W1PIbVVBWDyJxLq4D/2wgQjEGhymoXQIW8hvYaWv6V85842KxUazRlpw5+5jNPONAroEIh0cZQIuZtI3yrnn8YNQ9HLbBC7OJSDaA+Bh5w70bL7x1Oo/wHg4lvS+fKL3+nwoOpGEWkUpqmdWwISAFMh7EYU/iWCHd9j62Or2l0ddfOpL5tWh7slFH3RMCVglpgSsElMCVokpAavE/wND4U7qox2HAQAAAABJRU5ErkJggg=="),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class CustomApiManagerPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new CustomApiManagerControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public CustomApiManagerPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}