import BaseModal from "../../common/BaseModal";
import { ErrorMessage, Field, Form, Formik } from "formik";
import { Task } from "../../types/types";
import { Button, FormLabel } from "react-bootstrap";
interface TaskAddEditModalProps {
  onClose: () => void;
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
  model,
}: TaskAddEditModalProps) {
  return (
    <BaseModal title="Add a new task" onClose={onClose}>
      <Formik
        initialValues={model || new Task()}
        validate={validateForm}
        onSubmit={(values, { setSubmitting }) => {
          setTimeout(() => {
            alert(JSON.stringify(values, null, 2));
            setSubmitting(false);
          }, 400);
        }}
      >
        {({ isSubmitting }) => (
          <Form>
            <div>
              <FormLabel htmlFor="title">Title</FormLabel>
              <Field type="text" id="title" name="title" />
              <ErrorMessage name="title" component="div" />
            </div>

            <div>
              <FormLabel htmlFor="description">Description</FormLabel>
              <Field type="text" id="description" name="description" />
              <ErrorMessage name="description" component="div" />
            </div>

            <Button type="submit" disabled={isSubmitting}>
              Submit
            </Button>
          </Form>
        )}
      </Formik>
    </BaseModal>
  );
}
