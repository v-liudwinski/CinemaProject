import useSeanses from "../../hooks/SeanseHook";
import AdminPage from "../../components/ui/AdminPage";
import Seanses from "./Seanses";
import image from "../../assets/Main.png";

const SeanseManagement: React.FC<{}> = () => {
    const { showSeanse, setShowSeanse } = useSeanses();       
   
    return (
        <div style={{ backgroundImage: `url(${image})`}} className="min-vh-100">
            <AdminPage/>
            {showSeanse && <Seanses setShowSeanse={setShowSeanse} />}
        </div>
    );
};

export default SeanseManagement;
