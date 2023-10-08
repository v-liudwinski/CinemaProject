import React, { useEffect, useState } from "react";
import image from "../../assets/Main.png";
import axios from "axios";
import Upcoming from "../../types/upcomingTypes/Upcoming";
import UpcomingCard from "../../components/UserActions/UpcomingCard";

const UpcomingPage: React.FC<{}> = () => {
    const [upocomings, setUpcomings] = useState<Upcoming[]>([]);

    async function fetchUpcomings() {
        const response = await axios.get(
            "https://api.themoviedb.org/3/movie/upcoming?api_key=100f11f92f343c0ff96b981dfb2b1ee7&language=en-US&page=1"
        );
        setUpcomings(response.data.results);
    }

    useEffect(() => {
        fetchUpcomings();
    }, []);

    return (
        <div
            style={{ backgroundImage: `url(${image})` }}
            className="min-vh-100 p-5 pt-5">
            {upocomings !== undefined && <div>
                {upocomings.map(x => <UpcomingCard key={x.id} upcoming={x} />)} 
            </div>}
        </div>
    );
};

export default UpcomingPage;
