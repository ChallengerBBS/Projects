import { useState, useEffect } from "react";
import { Task } from "../types/types";

const useTaskService = (): {
  tasks: Task[];
  createTask: (task: Task) => void;
  updateTask: (id: number, updatedTask: Task) => void;
  deleteTask: (id: number) => void;
} => {
  const storedTasks = JSON.parse(localStorage.getItem("tasks") || "");
  const [tasks, setTasks] = useState<Task[]>(storedTasks);

  useEffect(() => {
    const json = JSON.stringify(tasks);
    localStorage.setItem("tasks", json);
    console.log("Set tasks to localStorage");
  }, [tasks]);

  const createTask = (task: Task) => {
    task.id = tasks.length + 1;
    setTasks((prevTasks) => [...prevTasks, task]);
    console.log("Added a task " + JSON.stringify(task));
  };

  const updateTask = (id: number, updatedTask: Task) => {
    setTasks((prevTasks) =>
      prevTasks.map((task) => (task.id === id ? updatedTask : task))
    );

    console.log("Updated a task " + JSON.stringify(updatedTask));
  };

  const deleteTask = (id: number) => {
    setTasks((prevTasks) => prevTasks.filter((task) => task.id !== id));

    console.log("Deleted a task ID: " + id);
  };

  return { tasks, createTask, updateTask, deleteTask };
};

export default useTaskService;
