

 Repo => Services => ApiControler

CleanQuote.DATA

  Entities : The quote Class.
	
  
  Repositories : Load the quote in the CSV file.
	

CleanQuote.Services

	Get the quotes from the Repo and do the logic.
	
	Quotes filter : All the logic for filtering quotes is here. I've use the composite pattern.

CleanQuoteApi

	Get the API call and use the service layer to do the logic and get the quotes.
	Read the quote from the CSV file one time and put it in cache.

CleanQuote.TEST

	Here i've Test the Services layer logic.
	I've use the NSubstitute nuget
	

	
Thank you, hope you liked my code !
