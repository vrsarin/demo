Feature: AddProducts

A short summary of the feature

@producttag1
Scenario: Add new product
	Given The product has a new guid
	And The product name is 'Lathe'
	And The product SKU is 'MICR-3201'
	And The product BasePrice is  45000.00
	When Post the product using url '/v1/products'
	Then api should return httpstatuscode 200
