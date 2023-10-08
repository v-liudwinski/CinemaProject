import MovieInfo from "../../types/movieTypes/MovieInfo";
import { useNavigate } from "react-router-dom";

interface MovieItemShowProps {
   movie: MovieInfo
    
}

const MovieItemShow: React.FC<MovieItemShowProps> = ({movie}) => {
    const navigate = useNavigate();

    return (
       
            <div style={{ width: '12.6rem' }} className="movie px-0 m-5 p-0 bg-black border">           
                  
                 <img className="cursor-state"  onClick={() => navigate(`/movies/singlemovie/${movie.id}`)} src={movie.posterUrl} width={200} height={300}/>                    
         
            </div>
       
    )

}

export default MovieItemShow;