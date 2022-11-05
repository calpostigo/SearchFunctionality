using NUnit.Framework;
using FluentAssertions;
using System;

namespace SearchFunctionality {
    public class SearchFuntionalityShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_empty_array_when_search_fewer_than_two_characters() {

            var result = Cities.SearchCities(string.Empty);

            result.Should().BeNullOrEmpty();
        }

        [TestCase("V")]
        [TestCase("P")]
        public void return_empty_array_when_search_equals_to_one_character(string characters) {

            var collection = Cities.SearchCities(characters);

            collection.Should().BeNullOrEmpty();
        }

        [Test]
        public void return_Valencia_and_Vancouver_when_search_equals_to_Va() {

            var charactersToSearch = "Va";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().Equal(new[] {"Valencia", "Vancouver"});
        }

        [Test]
        public void return_Paris_when_search_begin_for_Pa() {

            var charactersToSearch = "Pa";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().Equal(new[] { "Paris" });
        }

        [TestCase ("Hong")]
        [TestCase("Sko")]
        [TestCase("Rome")]
        public void return_city_when_search_begin_for_any_quantity_of(string charactersToSearch) {

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().BeSubsetOf(Cities.cities); 
        }

        [Test]
        public void return_city_array_when_search_contain_any_characters () {

            var charactersToSearch = "opj";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().BeSubsetOf(Cities.cities)
                .And.HaveCount(1);
        }

        [Test]
        public void return_city_array_when_search_contain_any_characters_and_case_insensitive () {

            var charactersToSearch = "NCOUVE";

            var collection = Cities.SearchCities(charactersToSearch);

            collection.Should().BeSubsetOf(Cities.cities)
                .And.HaveCount(1);
        }
    }

    public abstract class Cities {
        internal static string[] cities = new string[] {
            "Paris","Budapest","Skopje",
            "Rotterdam","Valencia","Vancouver",
            "Amsterdam","Vienna","Sydney",
            "New York City","London","Bangkok"
            ,"Hong Kong","Dubai","Rome","Istanbul"
        };
        public static string[] SearchCities(string search) {
            if (search.Length < 2) return new string[] { };
            var quantityOfCharacteres = search.Length;
            return Array.FindAll(cities, Match(search));
        }

        private static Predicate<string> Match(string search) {
            return city => city.ToUpper().Contains(search.ToUpper());
        }
    }
}