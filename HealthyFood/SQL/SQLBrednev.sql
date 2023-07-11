Select count(*)
from Games G 
left join (
	Select GC.GamesId, count(GC.GenresId) as genres
	from Games as G
	left join GameGameCategory GC on GC.GamesId = G.Id
	group by GC.GamesId) 
as GM on GM.GamesId = G.Id
left join (
	Select GC1.SecondaryGamesId, count(GC1.SecondaryGenresId) as secondGenres
	from Games as G
	left join GameGameCategory1 GC1 on GC1.SecondaryGamesId = G.Id
	group by GC1.SecondaryGamesId) 
as GS on GS.SecondaryGamesId = G.Id

Where GM.genres = GS.secondGenres 