import { useState } from "react";
import { Button } from "react-bootstrap";

import Task from "./Task";
import TaskAddEditModal from "./TaskAddEditModal";
import useTaskService from "../../hooks/useTaskService";

export default function TasksList() {
  const [isNewTaskModalVisible, setIsNewTaskModalVisible] = useState(false);
  const { tasks, createTask, updateTask, deleteTask } = useTaskService();

  const sortedTasks = tasks.sort((a, b) => b.priority - a.priority);

  return (
    <>
      <div className="row">
        <div className="col-2">
          {sortedTasks.map((task) => (
            <Task task={task} key={task.id}></Task>
          ))}
        </div>

        <div className="col-3">
          <Button
            variant="warning"
            onClick={() => {
              setIsNewTaskModalVisible(true);
            }}
          >
            Add a new task
          </Button>
        </div>

        {isNewTaskModalVisible && (
          <TaskAddEditModal
            onClose={() => setIsNewTaskModalVisible(false)}
            onCreateTask={createTask}
            onEditTask={updateTask}
          />
        )}
      </div>
    </>
  );
}
