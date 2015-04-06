using System; // ***** Static main may be put inside class
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Eoen
{
  /**
  * Esperanto AnywhereCS, Version 1.0, Esperanto-to-English Machine Translation
  *
  * @author David Kenneth Crandall, © 2014.
  */
  // Ĉ  ĉ  Ĝ  ĝ  Ĥ  ĥ  Ĵ  ĵ  Ŝ  ŝ  Ŭ  ŭ: circumflexes and breves
  // Cx cx Gx gx Hx hx Jx jx Sx sx Ux ux: X-method
  // Ch ch Gh gh Hh hh Jh jh Sh sh U  u: H-method

  public partial class Form1 : Form {

    EsperantoAnywhere ea;

    public Form1()
    {
      InitializeComponent();
    }

    public void Form1_Load(object sender, EventArgs e)
    {
      textBox1.Focus();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      EsperantoAnywhere.dontTranslateCapWords = !EsperantoAnywhere.dontTranslateCapWords;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      EsperantoAnywhere.circumflexCorrection = !EsperantoAnywhere.circumflexCorrection;
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    { // Allow H-Method: ch gh jh hh sh
      EsperantoAnywhere.H_Method = !EsperantoAnywhere.H_Method;
    }

    private void button1_Click(object sender, EventArgs e)
    { // Translate button
      try
      {
        if (ea == null)
        {
          ea = new EsperantoAnywhere();
        }
        //EsperantoAnywhere ea = new EsperantoAnywhere();
        String txxt = Regex.Replace(textBox1.Text, "\\bl['`‘’´] ", "la "); // Replace l' apostrophe: l' -> la
        txxt = Regex.Replace(txxt, "\\bL['`‘’´] ", "La ");
        txxt = Regex.Replace(txxt, "\\bl['`‘’´]", "la ");
        txxt = Regex.Replace(txxt, "\\bL['`‘’´]", "La ");
        textBox1.Text = Regex.Replace(txxt, "['`‘’´]([ .,?!:;)])", "o$1"); // Replace noun apostrophe: pom' -> pomo
        textBox2.Text = ea.translateEsperanto(textBox1.Text);
        textBox1.Text = EsperantoAnywhere.textIn2;
        textBox1.SelectionStart = textBox1.Text.Length;
        textBox1.SelectionLength = 0;
        textBox1.Focus();
      }
      catch (Exception ee)
      {
        Exception ee2 = ee;
        textBox2.Text = "Untranslatable. Ne tradukebla.";
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      textBox1.Text = EsperantoAnywhere.instructions;
      textBox2.Text = EsperantoAnywhere.instructions2;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      textBox1.Text = "";
      textBox2.Text = "";
      textBox1.Focus();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      letterSend("ĉ");
    }

    private void button5_Click(object sender, EventArgs e)
    {
      letterSend("ĝ");
    }

    private void button6_Click(object sender, EventArgs e)
    {
      letterSend("ĥ");
    }

    private void button7_Click(object sender, EventArgs e)
    {
      letterSend("ĵ");
    }

    private void button8_Click(object sender, EventArgs e)
    {
      letterSend("ŝ");
    }

    private void button9_Click(object sender, EventArgs e)
    {
      letterSend("ŭ");
    }

    private void button10_Click(object sender, EventArgs e)
    {
      letterSend("Ĉ");
    }

    private void button11_Click(object sender, EventArgs e)
    {
      letterSend("Ĝ");
    }

    private void button12_Click(object sender, EventArgs e)
    {
      letterSend("Ĥ");
    }

    private void button13_Click(object sender, EventArgs e)
    {
      letterSend("Ĵ");
    }

    private void button14_Click(object sender, EventArgs e)
    {
      letterSend("Ŝ");
    }

    private void button15_Click(object sender, EventArgs e)
    {
      letterSend("Ŭ");
    }

    private void letterSend(string value)
    {
      textBox1.Text = textBox1.Text.Substring(0, textBox1.SelectionStart) + value +
        textBox1.Text.Substring(textBox1.SelectionStart + textBox1.SelectionLength);
      textBox1.SelectionStart = textBox1.Text.Length;
      textBox1.SelectionLength = 0;
      textBox1.Focus();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
  }


}
