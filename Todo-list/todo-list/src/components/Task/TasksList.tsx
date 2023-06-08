import { useState } from "react";
import { Button } from "react-bootstrap";
import { Task as TaskType } from "../../types/types";

import Task from "./Task";
import TaskAddEditModal from "./TaskAddEditModal";
import useTaskService from "../../hooks/useTaskService";

export default function TasksList() {
  const [isNewTaskModalVisible, setIsNewTaskModalVisible] = useState(false);
  const [selectedTaskForEdit, setSelectedTaskForEdit] = useState<
    TaskType | undefined
  >(undefined);
  const { tasks, createTask, updateTask, deleteTask } = useTaskService();

  const sortedTasks = tasks.sort((a, b) => b.priority - a.priority);

  return (
    <>
      <Button
        variant="info"
        onClick={() => {
          setIsNewTaskModalVisible(true);
        }}
      >
        Add a new task
      </Button>

      {sortedTasks.map((task) => (
        <Task
          task={task}
          key={task.id}
          selectTaskForEdit={() => {
            setSelectedTaskForEdit(task);
            setIsNewTaskModalVisible(true);
          }}
          deleteTask={() => deleteTask(task.id)}
        />
      ))}

      {isNewTaskModalVisible && (
        <TaskAddEditModal
          onClose={() => {
            setIsNewTaskModalVisible(false);
            setSelectedTaskForEdit(undefined);
          }}
          onCreateTask={createTask}
          onEditTask={updateTask}
          model={selectedTaskForEdit}
        />
      )}
    </>
  );
}
