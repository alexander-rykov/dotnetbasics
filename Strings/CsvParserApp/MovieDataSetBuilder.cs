using System;
using System.Collections.Generic;
using CsvParserApp.CsvModel;
using CsvParserApp.Models;

namespace CsvParserApp
{
    /// <summary>
    /// Represents a builder for <see cref="IMovieDataSetBuilder"/>. Read more about Builder design pattern: https://refactoring.guru/design-patterns/builder
    /// </summary>
    public class MovieDataSetBuilder : IMovieDataSetBuilder
    {
        public void AddMovies(IEnumerable<MovieRow> movies)
        {
            if (movies == null)
            {
                throw new ArgumentNullException(nameof(movies));
            }

            // TODO Implement functionality.
        }

        public void AddRatings(IEnumerable<RatingRow> ratings)
        {
            if (ratings == null)
            {
                throw new ArgumentNullException(nameof(ratings));
            }

            // TODO Implement functionality.
        }

        public void AddTags(IEnumerable<TagRow> tags)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            // TODO Implement functionality.
        }

        public MovieDataSet Build()
        {
            // TODO Implement functionality to convert raw data into the data set model.

            return new MovieDataSet();
        }
    }
}
