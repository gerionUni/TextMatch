using Microsoft.AspNetCore.Mvc;

namespace TextMatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextMatchController : ControllerBase
    {
 
        [HttpPost(Name = "TextMatch")]
        public string MatchText(string text, string subtext)
        {
          
            string output = "";
            TextMatch Input = new TextMatch
            {
                Text = text.ToLower(),
                SubText = subtext.ToLower()

            };
            int subLength = Input.SubText.Length;
            int textLength = Input.Text.Length;
            for (int i = 0; i< textLength; i++)
            {
                int counter = 0;
                bool found = true;
                while (found && counter < subLength)
                {
                    if (i + counter > textLength - 1)
                    {
                        found = false;
                        break;
                    }
                    if (Input.Text[i + counter] != Input.SubText[counter])
                    {
                        found = false;
                    }
                    counter++;
                }
                if (found)
                {
                    output += (i + 1) + ",";
                }
            }
            if (output.Length == 0)
            {
                output = "There is no output";
            }
           
            return output.TrimEnd(',');
  
        }
    }
}
