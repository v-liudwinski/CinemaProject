import React, { useCallback, useState } from "react"
import { useDropzone } from "react-dropzone"
import { Modal } from 'react-bootstrap';
import http from "../../http-common";
import { getCurrentUserId } from "../../hooks/getCurrentUserId";

const UploadImageForm: React.FC<{}> = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [paths, setPaths] = useState([])
  const [image, setImage] = useState(null)

  const onDrop = useCallback((acceptedFiles: any) => {
    setPaths(acceptedFiles.map((file: any) => {
      setImage(file)
      return URL.createObjectURL(file)
    }))
  }, [setPaths])

  const { getRootProps, getInputProps } = useDropzone({ 
    onDrop,
    accept: 'image/jpeg, image/png'
  })

  const handleOpenModal = () => {
    setIsModalOpen(true);
  }

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  const handleSumnit = async () => {
    const formData = new FormData()
    if (image !== null){
      formData.append('image', image)
    }
    const userId = getCurrentUserId()
    await http.post(`/files?userId=${userId}`, formData, {
      headers: {
        'Content-Type': 'multipart/form-data'
      }
    }).then(response => {
      console.log(response.data);
      window.location.href='/account'
    }).catch(error => {
      console.error(error);
    })
    setIsModalOpen(false)
    setPaths([])
  }

  return (
    <>
      <button className="text-white btn btn-outline-primary me-md-2" onClick={handleOpenModal}>
        Завантажити фото
      </button>
      <Modal show={isModalOpen} onHide={handleCloseModal}>
        <Modal.Header className="bg-dark text-light" closeButton>
          <Modal.Title>Додати аватар</Modal.Title>
        </Modal.Header>
        <Modal.Body className="bg-dark text-light" style={{ minHeight: 250 }}>
          <div className="drop-area">
            <div {...getRootProps()} className={paths.length === 0 ? "cursor-state dropzone-box" : "cursor-state"}>
              <input {...getInputProps()} />
              { paths.length === 0 &&
              <p>Перетягніть своє зображення сюди або натисніть</p> }
            </div>
            {paths.map(path => <img key={path} src={path} className="img-thumbnail" />)}
            { paths.length !== 0 &&
              <div className="d-flex justify-content-center">
                <button onClick={handleSumnit} className="text-white btn btn-outline-primary mt-3">Завантажити</button>
              </div>
            }
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default UploadImageForm;