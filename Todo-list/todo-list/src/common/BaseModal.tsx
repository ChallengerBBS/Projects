import { ReactNode } from "react";
import { Modal } from "react-bootstrap";

interface BaseModalProps {
  children: ReactNode;
  onClose: () => void;
  title: string;
}

export default function BaseModal({
  children,
  onClose,
  title,
}: BaseModalProps) {
  return (
    <Modal show={true} onHide={onClose} backdrop="static" keyboard={false}>
      <Modal.Header closeButton>
        <Modal.Title>{title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>{children}</Modal.Body>
    </Modal>
  );
}
