import { TasksProps } from './Tasks.definitions';
import styles from './task.module.css';

export default function Task(props: TasksProps) {

    return (
        <>
            <div className={styles.task}>
                <span className={styles.title}>
                    {props.task.title}
                </span>
                <hr/>
                <span className={styles.description}>
                    {props.task.description}
                </span>
            </div>
        </>
    );
}