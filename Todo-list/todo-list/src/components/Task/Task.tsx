import { Button } from "react-bootstrap";
import { Task as TaskType } from "../../types/types";

import styles from "./task.module.css";

interface TasksProps {
  task: TaskType;
  selectTaskForEdit: () => void;
  deleteTask: () => void;
}

export default function Task(props: TasksProps) {
  return (
    <>
      <div className={styles.task}>
        <span className={styles.title}>{props.task.title}</span>
        <hr />
        <span className={styles.description}>{props.task.description}</span>
        <div className="row">
          <div className="col">
            <Button
              variant="warning"
              type="button"
              onClick={props.selectTaskForEdit}
            >
              Edit
            </Button>
          </div>
          <div className="col">
            <Button variant="danger" type="button" onClick={props.deleteTask}>
              Delete
            </Button>
          </div>
        </div>
      </div>
    </>
  );
}
