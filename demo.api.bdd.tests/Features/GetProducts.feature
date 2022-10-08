Feature: GetProducts

A short summary of the feature

@producttag2
Scenario: fetch all products
	Given Get api call product using url '/v1/products'	
	Then api should return list of products
