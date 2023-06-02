import { ReactNode } from "react";
import { Modal, Button } from "react-bootstrap";

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
    <>
      <Modal>
        <Modal.Dialog>
          <Modal.Header>
            <h2>{title}</h2>
            <Button className="close-button" onClick={onClose}>
              <span>&times;</span>
            </Button>
          </Modal.Header>
          <Modal.Body>{children}</Modal.Body>
        </Modal.Dialog>
      </Modal>
    </>
  );
}
