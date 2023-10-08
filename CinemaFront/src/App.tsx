import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Header } from "./components/ui/header";
import Home from "./pages/Home/Home";
import Cinema from "./pages/Admin/Cinemas";
import MoviePosters from "./pages/Movies/MoviePosterManager";
import { FAQ } from "./pages/Home/FAQ";
import AdminMain from "./pages/Admin/Main"
import Account from "./pages/Authentication/Account";
import Users from "./pages/Admin/Users";
import Movies from "./pages/Admin/Movie";
import Seanses from "./pages/Admin/Seanses";
import CinemasManagement from "./pages/Admin/CinemaManagement";
import MovieManagement from "./pages/Admin/MovieManagement";
import SeanseManagement from "./pages/Admin/SeanseManagement";
import PriceManagement from "./pages/Admin/PriceManagement";
import { Footer } from "./components/ui/footer";
import Promocodes from "./pages/Admin/Promocodes";
import SingleMovie from "./pages/Movies/SingleMovie";
import SeansePage from "./pages/Seance/SeansePage";
import MovieItem from "./components/Admin/movies/MovieItem";
import UpcomingPage from "./pages/Upcoming/Upcoming";

function App() {
    const token = localStorage.getItem("token");
    const role = localStorage.getItem("role");

    return (
        <div>
            <BrowserRouter>
                <Header/>
                <div>
                    <Routes>
                        <Route path="/" element={<Home />}></Route>
                        { token && <Route path="/account" element={<Account />}></Route> }
                        <Route path="/movies/moviepostermanager" element={<MoviePosters/>}></Route>
                        <Route path="/movies/seances" element={<SeansePage />}></Route>
                        {
                            role === "Admin" &&
                            <>
                                <Route path="/admin/users" element={<Users />}></Route>
                                <Route path="/admin/movie" element={<MovieManagement/>}></Route>
                                <Route path="/admin/pricemanagement" element={<PriceManagement/>}></Route>
                                <Route path="/admin/promocodes" element={<Promocodes />}></Route>
                                <Route path="/admin/cinemamanagement" element={<CinemasManagement />}></Route>
                                <Route path="/admin/moviemanagement" element={<MovieManagement />}></Route>
                                <Route path="/admin/seansemanagement" element={<SeanseManagement />}></Route>
                                
                            </>
                        }
                        <Route path="/home/faq" element={<FAQ/>}></Route>
                        <Route path="/movies/singlemovie/:id" element={<SingleMovie/>}></Route>
                        <Route path="/upcoming" element={<UpcomingPage />}></Route>
                    </Routes>

                    <Footer/>
                </div>               
            </BrowserRouter>
        </div>
    );
}

export default App;
