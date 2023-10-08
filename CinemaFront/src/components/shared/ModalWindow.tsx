import React from "react";
import { Modal } from "react-bootstrap";

interface ModalProps {
    children: React.ReactNode;
    title: string;
    close: () => void;
    modal: boolean;
    size: string;
}

const ModalWindow: React.FC<ModalProps> = ({ children, title, close, modal, size }) => {
    return (
        <>
            <Modal show={modal} onHide={close} size={size === "xl" ? "xl" : size === "lg"? "lg" : "sm"}>
                <Modal.Header className="bg-dark text-light" closeButton>
                    <Modal.Title>{ title }</Modal.Title>
                </Modal.Header>
                <Modal.Body className="bg-dark text-light"> 
                    { children }
                </Modal.Body>
            </Modal>
        </>
    );
};

export default ModalWindow;
