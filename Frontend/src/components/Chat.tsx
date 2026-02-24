import { Stack, ScrollArea } from "@mantine/core";
import { ChatInput } from "./Chat.Input";
import { ChatMessage } from "./Chat.Message";
import { palette } from "./pallette";

export function Chat() {
  return (
    <Stack
      gap={0}
      style={{
        flex: 1,
        height: "100%",
        background: palette.bg,
        color: palette.text,
      }}
    >
      <ScrollArea style={{ flex: 1 }}>
        <Stack p="sm">
          <ChatMessage />
        </Stack>
      </ScrollArea>
      <ChatInput />
    </Stack>
  );
}
