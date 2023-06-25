import BaseModal from "../../common/BaseModal";
import { ErrorMessage, Field, Form, Formik } from "formik";
import { Task } from "../../types/types";
import { Button, FormLabel } from "react-bootstrap";

interface TaskAddEditModalProps {
  onClose: () => void;
  onCreateTask: (task: Task) => void;
  onEditTask: (id: number, updatedTask: Task) => void;
  model?: Task;
}

const validateForm = (values: Task) => {
  const errors: Partial<Task> = {};

  if (!values.title) {
    errors.title = "Title is required";
  }

  return errors;
};

export default function TaskAddEditModal({
  onClose,
  onCreateTask,
  onEditTask,
  model,
}: TaskAddEditModalProps) {
  return (
    <BaseModal title="Add a new task" onClose={onClose}>
      <Formik
        initialValues={model || new Task()}
        validate={validateForm}
        onSubmit={(values) => {
          if (model) {
            onEditTask(model.id, values);
            onClose();
            return;
          }

          onCreateTask(values);
          onClose();
        }}
      >
        {({ isSubmitting }) => (
          <Form>
            <div style={{ alignContent: "left" }}>
              <div>
                <FormLabel htmlFor="title">Title:&nbsp;</FormLabel>
                <Field type="text" id="title" name="title" />
                <ErrorMessage name="title" component="div" />
              </div>

              <div>
                <FormLabel htmlFor="description">Description:&nbsp;</FormLabel>
                <Field type="text" id="description" name="description" />
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <Button type="button" variant="secondary" onClick={onClose}>
                  Cancel
                </Button>
              </div>
              <div className="col-6">
                <Button type="submit" variant="primary" disabled={isSubmitting}>
                  Submit
                </Button>
              </div>
            </div>
          </Form>
        )}
      </Formik>
    </BaseModal>
  );
}
