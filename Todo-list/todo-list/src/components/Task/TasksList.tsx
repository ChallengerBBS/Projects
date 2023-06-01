import { Button } from "react-bootstrap";
import { tasks } from "../../util/dummyData";
import Task from "./Task";

export default function TasksList() {
  const sortedTasks = tasks.sort((a, b) => b.priority - a.priority);

  return (
    <>
      <div className="row">
        <div className="col-2">
          {sortedTasks.map((task) => (
            <Task task={task}></Task>
          ))}
        </div>

        <div className="col-3">
          <Button>Add a new task</Button>
        </div>
      </div>
    </>
  );
}
