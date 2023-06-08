import { useState, useEffect } from "react";
import { Task } from "../types/types";

const useTaskService = (): {
  tasks: Task[];
  createTask: (task: Task) => void;
  updateTask: (id: number, updatedTask: Task) => void;
  deleteTask: (id: number) => void;
} => {
  const [tasks, setTasks] = useState<Task[]>([]);

  useEffect(() => {
    const storedTasks = localStorage.getItem("tasks");
    if (storedTasks) {
      setTasks(JSON.parse(storedTasks));
    }
  }, []);

  useEffect(() => {
    const json = JSON.stringify(tasks);
    localStorage.setItem("tasks", json);
    console.log(json);
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
  };

  const deleteTask = (id: number) => {
    setTasks((prevTasks) => prevTasks.filter((task) => task.id !== id));
  };

  return { tasks, createTask, updateTask, deleteTask };
};

export default useTaskService;
