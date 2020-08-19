select Genre.Name as genre, Movies.Name as moviename, Movies.GenreId from movies
inner join genre on movies.GenreId = genre.Id