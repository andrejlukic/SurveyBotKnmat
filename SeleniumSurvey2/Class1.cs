using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSurvey2
{
    public class Class1
    {
        static void Main(string[] args) 
        {
            
            var r = new Random(DateTime.Now.Millisecond);
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            
            IWebDriver driver = new ChromeDriver( /*@"C:\chromedriver" ,*/ options);          

            driver.Navigate().GoToUrl("http://surveys.valicon.net/CAWI/stl2016/RGF0YT1yZWYyJTdjNTtpZHRyZ292aW5lMiU3YzE4MDE");

            wait(r);

            fw(driver, r);

            int _step = 1;
            string condition = String.Empty;
            string conditionPrevious = String.Empty;
            while (_step < 36)
            {
                try
                {
                    conditionPrevious = condition;
                    condition = stepNext(r, driver, _step, condition);
                    _step++;
                }
                catch (Exception e)
                {
                    driver.Navigate().Refresh();
                    _step--;
                    condition = conditionPrevious;
                    int wait = r.Next(5000);
                    System.Threading.Thread.Sleep(wait);                    
                }
            }            
        }

        public static void typeTextBox(IWebDriver driver, Random rand, string id, string value)
        {
            IWebElement tb = driver.FindElement(By.Id(id));
            tb.SendKeys(value);
            int wait = rand.Next(1000, 3000);
            System.Threading.Thread.Sleep(wait);
        }
        public static void fw(IWebDriver driver, Random rand)
        {
            clickNAMEwait(driver, "WSS__BTN__Forward", rand);
        }
        public static string choose(string[] arr, Random rand)
        {
            int cnt = arr.Length;
            if (cnt == 1) return arr[0];

            return arr[rand.Next(0,cnt-1)];
        }

        public static void clickIDwait(IWebDriver driver, string id, Random r)
        {
            int tries = 3;
            bool success = false;
            // (1) Find the element that has the label text as its text
            IWebElement rb = null;

            while(!success &&  tries>0)
            {
                try
                {
                    rb = driver.FindElement(By.Id(id));
                    success = true;
                }
                catch (Exception e)
                {
                    tries--;
                    System.Threading.Thread.Sleep(2000);
                }
            }

            rb.Click();
            int wait = r.Next(1000, 3000);
            System.Threading.Thread.Sleep(wait);
        }

        public static void clickNAMEwait(IWebDriver driver, string name, Random r)
        {
            // (1) Find the element that has the label text as its text
            IWebElement rb = driver.FindElement(By.Name(name));

            rb.Click();

            int wait = r.Next(1000, 6000);
            System.Threading.Thread.Sleep(wait);
        }

        public static void wait(Random r)
        {
            int wait = r.Next(2000, 6000);
            System.Threading.Thread.Sleep(wait);
        }
        public static void ClickRadioButtonByLabelText(IWebDriver driver, string labelText)
        {
            // (1) Find the element that has the label text as its text
            IWebElement labelForButton = driver.FindElement(By.XPath("//label[text()='labelText']"));

            // (2) Get the FOR attribute from that element
            string forAttribute = labelForButton.GetAttribute("for");

            // (3) Find the input that has an id equal to that FOR attribute
            IWebElement radioElement = driver.FindElement(By.Id(forAttribute));

            // (4) Click that input element
            radioElement.Click();
        }
        public static string stepNext(Random r, IWebDriver driver, int step, string condition)
        {
            switch(step)
            {
                case 1:
                    string id = choose(new string[] { "RE_ID_BUY0_Opt_6",
                                              "RE_ID_BUY0_Opt_5",
                                              "RE_ID_BUY0_Opt_4" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 2:
                    id = choose(new string[] { "RE_ID_IN1ab1_Opt_1",
                                       "RE_ID_IN1ab1_Opt_2" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 3:
                    id = choose(new string[] { "RE_ID_IN1ac_Opt_2",
                                       "RE_ID_IN1ac_Opt_3",
                                       "RE_ID_IN1ac_Opt_4" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 4:
                    id = choose(new string[] { "RE_ID_IN1b_Opt_3",
                                       "RE_ID_IN1b_Opt_4"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 5:
                    id = choose(new string[] { "15",
                                       "25",
                                       "20",
                                       "30",
                                        "10"}, r);
                    typeTextBox(driver, r, "RE_ID_BUY1_Opt_0", id);
                    fw(driver, r);
                    break;
                case 6:
                    id = choose(new string[] { "RE_ID_BUY1art_Opt_1",
                                       "RE_ID_BUY1art_Opt_2",
                                       "RE_ID_BUY1art_Opt_3" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 7:
                    id = choose(new string[] { "RE_ID_WEBBUY2cat_Opt_1",
                                       "RE_ID_WEBBUY2cat_Opt_10" }, r); //rač ali avtomobilizem            
                    clickIDwait(driver, id, r);
                    clickIDwait(driver, "RE_ID_WEBBUY2cat_Opt_13", r); //hrana nima podkategorij
                    fw(driver, r);
                    return id;
                    break;
                case 8:
                    //subcategory:
                    if (condition == "RE_ID_WEBBUY2cat_Opt_1")
                    {
                        id = choose(new string[] { "RE_ID_WEBBUYcat1_Opt_2",
                                       "RE_ID_WEBBUYcat1_Opt_3"}, r);
                    }
                    else
                    {
                        id = choose(new string[] { "RE_ID_P041_6_5_Opt_35",
                                       "RE_ID_P041_6_5_Opt_36"}, r);
                    }
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 9:
                    id = choose(new string[] { "RE_ID_placilo_Opt_1",
                                       "RE_ID_placilo_Opt_4"}, r);
                    string kreditna = id == "RE_ID_placilo_Opt_4" ? "kreditna" : "";
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    return kreditna;
                    break;
                case 10:
                    if (condition == "kreditna")
                    {
                        id = choose(new string[] { "RE_ID_card_Opt_2",
                                       "RE_ID_card_Opt_1"}, r);
                        clickIDwait(driver, id, r);
                        fw(driver, r);
                    }
                    break;
                case 11:
                    id = choose(new string[] { "RE_ID_XC1SSG_Opt_3",
                                       "RE_ID_XC1SSG_Opt_4",
                                       "RE_ID_XC1SSG_Opt_5" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 12:
                    id = choose(new string[] { "RE_ID_XC1SXP_Opt_1",
                                       "RE_ID_XC1SXP_Opt_2",
                                       "RE_ID_XC1SXP_Opt_3" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 13:
                    id = choose(new string[] { "RE_ID_XC1NPS.1_Opt_1",
                                       "RE_ID_XC1NPS.1_Opt_2",
                                       "RE_ID_XC1NPS.1_Opt_3" }, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 14:
                    for(int i=1;i<15;i++)
                    {
                        string __tmp = "RE_ID_XC1SE1."+i+"_Opt_";
                        try
                        {
                            var rb = driver.FindElement(By.Id(__tmp + "1"));
                            id = __tmp + r.Next(1, 4);
                            clickIDwait(driver, id, r);
                            //this option exists
                        }
                        catch
                        {      
                            //failed to find                     
                        }
                    }
                    
                    fw(driver, r);
                    break;
                case 15:
                    id = choose(new string[] { "RE_ID_XC1PRB_Opt_3",
                                       "RE_ID_XC1PRB_Opt_2",
                                       "RE_ID_XC1PRB_Opt_1"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 16:
                    id = choose(new string[] { "RE_ID_XC1SCO_Opt_3",
                                       "RE_ID_XC1SCO_Opt_2"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 17:
                    for (int i = 1; i < 20; i++)
                    {
                        string _tmp = "RE_ID_XC1SE2." + i + "_Opt_";
                        try
                        {
                            var rb = driver.FindElement(By.Id(_tmp + "1"));
                            id = _tmp + r.Next(1, 4);
                            clickIDwait(driver, id, r);
                            //this option exists
                        }
                        catch
                        {
                        }
                    }                    
                    fw(driver, r);
                    break;
                case 18: 
                    id = choose(new string[] { "RE_ID_XC1SI1_div_Arrange.13",
                                       "RE_ID_XC1SI1_div_Arrange.8"
                                     }, r);
                    clickIDwait(driver, id, r);
                    id = choose(new string[] { "RE_ID_XC1SI1_div_Arrange.3",
                                       "RE_ID_XC1SI1_div_Arrange.11"
                                     }, r);
                    clickIDwait(driver, id, r);
                    id = choose(new string[] { "RE_ID_XC1SI1_div_Arrange.9",
                                       "RE_ID_XC1SI1_div_Arrange.7"
                                     }, r);
                    clickIDwait(driver, id, r);                    
                    clickIDwait(driver, "RE_ID_XC1SI1_div_Arrange.4", r);
                    clickIDwait(driver, "RE_ID_XC1SI1_div_Arrange.5", r);                    
                    fw(driver, r);
                    break;
                case 19:

                    try
                    {
                        clickIDwait(driver, "RE_ID_MOT3_div_Arrange.5", r);
                        clickIDwait(driver, "RE_ID_MOT3_div_Arrange.13", r);
                        clickIDwait(driver, "RE_ID_MOT3_div_Arrange.6", r);
                        clickIDwait(driver, "RE_ID_MOT3_div_Arrange.4", r);
                        clickIDwait(driver, "RE_ID_MOT3_div_Arrange.3", r);
                    }
                    catch
                    {                        
                    }

                    fw(driver, r);
                    break;
                case 20:
                    id = choose(new string[] { "RE_ID_KAT1_Opt_11",
                                       "RE_ID_KAT1_Opt_13",
                                       "RE_ID_KAT1_Opt_14"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 21:
                    clickIDwait(driver, "RE_ID_C1_STIM_Opt_21", r);
                    fw(driver, r);
                    break;
                case 22:
                    clickIDwait(driver, "RE_ID_C1_DIRECT_Opt_141", r);
                    fw(driver, r);
                    break;
                case 23:
                    id = choose(new string[] { "RE_ID_C1_ZMOT_Opt_8",
                                       "RE_ID_C1_ZMOT_Opt_7"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 24:
                    clickIDwait(driver, "RE_ID_C1_ZMOT2_Opt_96", r);
                    fw(driver, r);
                    break;
                case 25:
                    id = choose(new string[] { "RE_ID_C1_KANAL_Opt_1",
                                       "RE_ID_C1_KANAL_Opt_2",
                                       "RE_ID_C1_KANAL_Opt_4"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    return id;
                    break;
                case 26:
                    string tmp = condition.Replace("KANAL", "FINAL");
                    clickIDwait(driver, tmp, r);
                    fw(driver, r);
                    break;
                case 27:                    
                    fw(driver, r);
                    break;
                case 28:
                    int birth = r.Next(1978, 1988); //birth_year0
                    var birthdropdown = driver.FindElement(By.Id("birth_year0"));
                    var selectElement = new SelectElement(birthdropdown);
                    selectElement.SelectByValue(birth.ToString());

                    fw(driver, r);
                    break;
                case 29:
                    id = choose(new string[] { "RE_ID_Wactivity0_Opt_8",
                                               "RE_ID_Wactivity0_Opt_12",
                                               "RE_ID_Wactivity0_Opt_12",
                                               "RE_ID_Wactivity0_Opt_6"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 30:
                    id = choose(new string[] { "RE_ID_edu0_Opt_3",
                                               "RE_ID_edu0_Opt_5",
                                               "RE_ID_edu0_Opt_7",
                                               "RE_ID_edu0_Opt_9"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 31:
                    id = choose(new string[] { "RE_ID_pincome01_Opt_4",
                                               "RE_ID_pincome01_Opt_6",
                                               "RE_ID_pincome01_Opt_7",
                                               "RE_ID_pincome01_Opt_3"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 32:
                    id = choose(new string[] { "RE_ID_SI_nuts3_Opt_8",
                                               "RE_ID_SI_nuts3_Opt_7"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 33:
                    id = choose(new string[] { "RE_ID_gender0_Opt_1",
                                               "RE_ID_gender0_Opt_2"}, r);
                    clickIDwait(driver, id, r);
                    fw(driver, r);
                    break;
                case 34:
                    clickIDwait(driver, "RE_ID_sodelovanje_Opt_1", r);
                    fw(driver, r);
                    break;
                case 35:
                    clickIDwait(driver, "RE_ID_panel_Opt_2", r);
                    fw(driver, r);
                    fw(driver, r);
                    break;
                default:
                    throw new Exception("step not exists");


            }
            return String.Empty;
        }

    }
}
