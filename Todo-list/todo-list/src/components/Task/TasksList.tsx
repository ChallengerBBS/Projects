import { useState } from "react";
import { Button } from "react-bootstrap";
import { tasks } from "../../util/dummyData";

import Task from "./Task";
import BaseModal from "../../common/BaseModal";
import { log } from "console";

export default function TasksList() {
  const [isNewTaskModalVisible, setIsNewTaskModalVisible] = useState(false);

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
              console.log("hit");
              setIsNewTaskModalVisible(true);
            }}
          >
            Add a new task
          </Button>
        </div>

        {isNewTaskModalVisible && (
          <BaseModal
            title="test"
            onClose={() => setIsNewTaskModalVisible(false)}
          >
            asd
          </BaseModal>
        )}
      </div>
    </>
  );
}
