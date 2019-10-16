using CollegeMajorsMVVM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMajorsMVVM.Services
{
    public class MajorsDatastore
    {
        private List<Major> majors;

        public MajorsDatastore()
        {
            LoadMajors();
        }

        protected async Task LoadMajors()
        {
            List<Major> majorsList = new List<Major>();

            var assembly = typeof(Major).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"CollegeMajorsMVVM.Assets.recent-grads.csv");
            using (StreamReader reader = new StreamReader(stream))
            {

                await reader.ReadLineAsync();

                string line = await reader.ReadLineAsync();

                while (line != null)
                {
                    try
                    {
                        string[] par = line.Split(';');
                        Major major = new Major()
                        {
                            Name = par[0],
                            TotalMen = int.Parse(par[1]),
                            TotalWomen = int.Parse(par[2]),
                            Category = par[3],
                            TotalEmployed = int.Parse(par[4]),
                            TotalUnemployed = int.Parse(par[5])

                        };
                        majorsList.Add(major);
                    }
                    catch (Exception)
                    {

                        Debug.WriteLine($"Couldn't process line: {line}");
                    }

                    line = await reader.ReadLineAsync();
                }

            }
            majors = majorsList;
        }
        public async Task<List<Major>> GetMajors()
        {
            return await Task.FromResult(majors);
        }
        
        public async Task<List<string>> GetUniqueCategories()
        {
            List<string> categories = new List<string>();
            foreach (Major major in (await GetMajors()))
            {
                if (!categories.Contains(major.Category))
                {
                    categories.Add(major.Category);
                }
            }
            return categories;
        }
        public async Task<List<Major>> GetMajorsByCategory(string cat)
        {
            List<Major> majors = new List<Major>();
            foreach (Major major in (await GetMajors()))
            {
                if (major.Category.ToLower() == cat.ToLower())
                {
                    majors.Add(major);
                }
            }
            return majors;
        }
    }
}
