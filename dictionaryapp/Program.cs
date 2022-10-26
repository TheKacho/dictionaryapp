//API: Setup interaction

using System.Text.Json;
using dictionaryapp;

string baseUrl = "https://api.dictionaryapi.dev/api/v2/entries/en/";
//dictionary api link to assign to baseURL

// sets the http client to the baseURL to make a new instance upon
// app startup

HttpClient client = new HttpClient()
{
    BaseAddress = new Uri(baseUrl)
};

// tells user to either input a word or 'q' to exit
Console.WriteLine("Please enter in a word to recieve the definition.");
Console.WriteLine("Or press 'Q' to exit");
var userInput = Console.ReadLine();

//while loop when it is not equal to q
while(userInput != "q")
{
    var response = await client.GetAsync(userInput);
    var content = await response.Content.ReadAsStringAsync();
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    // allows user to input word regardless if uppercase or not

    List<DictionaryResponseModel> definitionInfoList;
    try
    {
        definitionInfoList = JsonSerializer.Deserialize<List<DictionaryResponseModel>>(content, options);
    }
    catch (JsonException)
    {
        Console.WriteLine("That's not a real word, sorry.");
        Console.WriteLine("Please enter a word to recieve the definition");
        Console.WriteLine("Or enter 'q' to exit the app.");
        userInput = Console.ReadLine();
        continue;
        // catch exception if the input word does not find any results
    }

    // the app will display either the first or default definition for user's word
    Console.WriteLine($"Word: {definitionInfoList.FirstOrDefault().Word}");

    foreach (var definitionInfo in definitionInfoList)
    {
        foreach (var meaning in definitionInfo.Meanings)
        {
            var partOfSpeech = meaning.PartOfSpeech;
            foreach (var definition in meaning.Definitions)
            {
                Console.WriteLine($"{partOfSpeech} : {definition.Definition}"); ;
            }
        }      
    }

    Console.WriteLine("Enter in a word to get definition:");
    Console.WriteLine("Enter 'q' to exit program");
    userInput = Console.ReadLine();
}