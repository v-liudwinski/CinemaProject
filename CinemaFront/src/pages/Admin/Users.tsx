import { Container, Table } from "react-bootstrap";
import UserRow from "../../components/Admin/Users/UserRow";
import useUsers from "../../hooks/UsersHook";
import { useContext, useEffect, useState } from "react";
import ShowUser from "../../components/Admin/Users/ShowUser";
import { ModalContext } from "../../context/ModalContext";
import ModalWindow from "../../components/shared/ModalWindow";
import PurchasesUser from "../../components/Admin/Users/PurchasesUser";
import DeleteUser from "../../components/Admin/Users/DeleteUser";
import UpdateUserRole from "../../components/Admin/Users/UpdateUserRole";
import AdminPage from "../../components/ui/AdminPage";
import image from "../../assets/Main.png";

const Users: React.FC<{}> = () => {
    
    const { users, deleteUser, getUser, user, fetchUsers } = useUsers();
    const { modal, open, close } = useContext(ModalContext);
    const [currentUserId, setCurrentUserId] = useState<number>(0);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [rerender, setRerender] = useState(false);
    const title: string = currentOption === 'updateUser' ? `Редагувати користувача Id ${currentUserId}` :
        currentOption === 'showUser'? `Користувач id ${currentUserId}` : currentOption === 'purchasesUser' ?
        `Покупки користувача id ${currentUserId}` : `Видалити користувача Id ${currentUserId}`

    useEffect(() => {
        fetchUsers();
    }, [rerender]);

    return (
        <div style={{ backgroundImage: `url(${image})`}} className="min-vh-100">
        <AdminPage />
            {users &&
                <Container fluid className="p-5 pt-3 text-center">
                    
                    {modal &&
                    <ModalWindow title={title} 
                        close={close}
                        modal={modal} 
                        size={size}>
                        {
                            currentOption === 'showUser' 
                                ? <ShowUser userId={currentUserId} getUser={getUser} user={user} />
                            : currentOption === 'purchasesUser' 
                                ? <PurchasesUser userId={currentUserId} /> 
                            : currentOption === 'updateUser' 
                                ? <UpdateUserRole userId={currentUserId} close={close} setRerender={setRerender} />
                            : <DeleteUser setRerender={setRerender} deleteUser={deleteUser} 
                            close={close} userId={currentUserId} />
                        }
                    </ModalWindow>}

                    <Table striped bordered hover className="mt-2 border" variant="dark" responsive>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Ім'я</th>
                            <th>Прізвище</th>
                            <th>Пошта</th>
                            <th>Телефон</th>
                            <th>Дата народження</th>
                            <th>Роль</th>
                            <th>Опції</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            users.map(x => 
                            <UserRow 
                                user={x} 
                                key={x.id} 
                                open={open}
                                modal={modal}
                                setCurrentUserId={setCurrentUserId}
                                setCurrentOption={setCurrentOption}
                                setSize={setSize}
                                />)
                        }
                    </tbody>
                    </Table>
                </Container>
            }
        </div>
    );
};

export default Users;
