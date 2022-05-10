using Instagram_Followers_Following;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;


const string path = @"D:\Instagram.txt";
Console.WriteLine("Iki Faktorlu Dogrulama varsa 1 yoksa 0 girin");
int sayi = Convert.ToInt32(Console.ReadLine());

IWebDriver driver = new OperaDriver(@"C:\Users\Emrullah\AppData\Local\Programs\Opera");
//OperaDriver driver = new OperaDriver(@"C:\Users\Emrullah\AppData\Local\Programs\Opera");



driver.Navigate().GoToUrl("https://www.instagram.com");
Console.WriteLine("Site Açıldı");
Thread.Sleep(2000);
IWebElement userName = driver.FindElement(By.Name("username"));
IWebElement password = driver.FindElement(By.Name("password"));
IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));


bilgiler bilgi = new bilgiler();
userName.SendKeys(bilgi.kullaniciAdi());
password.SendKeys(bilgi.sifre());
loginBtn.Click();
Console.WriteLine("Hesap Bilgileri Girildi");
Thread.Sleep(2000);

if (sayi == 1)
{
    Thread.Sleep(20000);
}
else
{

}

IWebElement followerLink = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a"));
followerLink.Click();
Thread.Sleep(2500);
string jsCommand = "" +
               "sayfa = document.querySelector('.isgrP');" +
               "sayfa.scrollTo(0,sayfa.scrollHeight);" +
               "var sayfaSonu = sayfa.scrollHeight;" +
               "return sayfaSonu;";

IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

while (true)
{
    var son = sayfaSonu;
    Thread.Sleep(750);
    sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
    if (son == sayfaSonu)
        break;
}
int sayac = 1;
IReadOnlyCollection<IWebElement> follwers = driver.FindElements(By.CssSelector(".FPmhX.notranslate._0imsa"));
if (!File.Exists(path))
{
    File.Create(path);
}
StreamWriter Yaz = new StreamWriter(path);

foreach (IWebElement follower in follwers)
{
    Yaz.WriteLine(sayac + "==>" + follower.Text);
    sayac++;

}
Console.ReadKey();