import { Group, Textarea } from "@mantine/core";
import { palette } from "./pallette";

export function ChatInput() {
  return (
    <Group
      gap={0}
      m="sm"
      p="sm"
      style={{
        background: palette.s2,
        borderRadius: 12,
        overflow: "hidden",
      }}
    >
      <Textarea
        placeholder="Message..."
        variant="unstyled"
        styles={{
          input: {
            color: palette.text,
          },
        }}
      />
    </Group>
  );
}
