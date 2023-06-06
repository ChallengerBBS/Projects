import BaseModal from "../../common/BaseModal";
import { ErrorMessage, Field, Form, Formik } from "formik";
import { Task } from "../../types/types";
interface TaskAddEditModalProps {
  onClose: () => void;
  model?: Task;
}

export default function TaskAddEditModal({
  onClose,
  model,
}: TaskAddEditModalProps) {
  return (
    <BaseModal title="Add a new task" onClose={onClose}>
      <Formik
        initialValues={model || new Task()}
        // validate={(values: Task) => {
        //   const errors = { email: "" };
        //   if (!values.email) {
        //     errors.email = "Required";
        //   } else if (
        //     !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
        //   ) {
        //     errors.email = "Invalid email address";
        //   }
        //   return errors;
        // }}
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
              <label htmlFor="title">Title</label>
              <Field type="text" id="title" name="title" />
              <ErrorMessage name="title" component="div" />
            </div>

            <div>
              <label htmlFor="description">Description</label>
              <Field type="text" id="description" name="description" />
              <ErrorMessage name="description" component="div" />
            </div>

            <button type="submit" disabled={isSubmitting}>
              Submit
            </button>
          </Form>
        )}
      </Formik>
    </BaseModal>
  );
}
