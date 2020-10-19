﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPIHost.Models;

namespace SampleAPIHost.Repository
{
    public class ProductRepository : IProductRepository
    {
        List<Models.Products> productList = new List<Products>();

        public ProductRepository()
        {
            productList.Add(new Products("P101", "Efficia CM Series", new string[]{"Touch_Screen", "Battery"}, new string[]{ "Only Spo2"}, "upto 10"));
            productList.Add(new Products("P102", "Goldway G40E", new string[] { "Battery" }, new string[] {  "ESN", "Resp","Others" }, "10"));
            productList.Add(new Products("P103", "IntelliVue AD75", new string[] { "Alarm" }, new string[] {  "Additional Display" }, "above 15"));
            productList.Add(new Products("P104", "IntelliVue MX100", new string[] { "Touch_Screen", "Handle", "Battery" }, new string[] { "ESN", "Resp", "CO2" }, "10"));
            productList.Add(new Products("P105", "IntelliVue MP5T", new string[] { "Touch_Screen" }, new string[] { "ESN", "Others" }, "10"));
            productList.Add(new Products("P106", "IntelliVue AD85", new string[] { "Alarm" }, new string[] {  "Additional Display" }, "above 15"));
            productList.Add(new Products("P107", "IntelliVue MX400", new string[] { "Alarm" }, new string[] {  "ESN", "Resp", "CO2", "Others" }, "10"));
            productList.Add(new Products("P108", "IntelliVue X3", new string[] { "Touch_Screen", "Handle", "Battery" }, new string[] { "ESN", "Resp"}, "10"));
            productList.Add(new Products("P109", "IntelliVue MX750", new string[] { "Touch_Screen", "Alarm" }, new string[] {"ESN", "Resp", "CO2" }, "above 15"));
            productList.Add(new Products("P110", "IntelliVue MP2", new string[] { "Alarm", "Battery" }, new string[] {  "ESN", "Resp" }, "10"));
            productList.Add(new Products("P111", "IntelliVue MP5", new string[] { "Touch_Screen", "Handle", "Battery" }, new string[] { "ESN" }, "10"));
            productList.Add(new Products("P112", "IntelliVueMX450", new string[] { "Alarm" }, new string[] { "ESN", "Resp", "CO2" }, "10-15"));

        }

        public void AddNewProduct(Products newProduct)
        {

            productList.Add(newProduct);
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return productList;
        }

        public IEnumerable<Products> GetAllProductsBasedOnQuestions(Dictionary<string, string[]> choiceDictionary)
        {
            List<Models.Products> productBasedOnQuestionList = new List<Products>();
            foreach (var product in productList)
            {
                if (IsProductSatisfy(product, choiceDictionary))
                {
                    productBasedOnQuestionList.Add(product);
                }
            }

            return productBasedOnQuestionList;
        }

        public bool IsProductSatisfy(Products product, Dictionary<string, string[]> choiceDictionary)
        {
            if (IsFeatureSatisfy(product, choiceDictionary))
            {
                return true;
            }
            return false;
        }

        public bool IsFeatureSatisfy(Products product, Dictionary<string, string[]> choiceDictionary)
        {

            if (product.Features.Intersect(choiceDictionary["Features"]).Count() !=0 && IsServicesSatisfy(product, choiceDictionary))
            {
                return true;
            }
            return false;
        }

        public bool IsServicesSatisfy(Products product, Dictionary<string, string[]> choiceDictionary)
        {
            if (product.Services.Intersect(choiceDictionary["Services"]).Count() != 0 && IsSizeSatisfy(product, choiceDictionary))
            {
                return true;
            }
            return false;
            
        }
        public bool IsSizeSatisfy(Products product, Dictionary<string, string[]> choiceDictionary)
        {
            if ((choiceDictionary["DisplaySize"]).Contains(product.DisplaySize))
            {
                return true;
            }
            return false;
        }
    }
}
